using System;
using System.Data;
using System.Data.SqlClient;

namespace CrudApplicationDB
{
    class Program
    {
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["abstractConnection"].ConnectionString;

        static SqlConnection con = new SqlConnection(connectionString);
        static SqlCommand commandInstance;
        static SqlDataReader dataReader;

        const string UPDATION = "UPDATION", DELETION = "DELETION", INSERTION = "INSERTION";
        static void Main(string[] args)
        { 
            try
            {
                con.Open();
                PerformUpdation();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                dataReader.Close();
                con.Close();
            }
            Console.ReadLine();
        }

        public static void PerformInsert()
        {
            Console.Write("Enter Name of Student : ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter Marks of Student : ");
            string inputMarks = Console.ReadLine();
            int marks;
            Int32.TryParse(inputMarks,out marks);

            string query = $"insert into student values ('{name}',{marks})";
            commandInstance = new SqlCommand(query,con);

            int affectedRowCount = commandInstance.ExecuteNonQuery();
            FinalResultDisplay(affectedRowCount,INSERTION);
            
        }

        public static void PerformUpdation()
        {
            DisplayAllStudent();
            int finalId = GetIdOfStudent();
            Console.WriteLine($"Changing name and marks of student with id : {finalId}");

            string query = $"update student set sname='VISHAL SINGH',marks=25 where sid={finalId}";
            commandInstance = new SqlCommand(query,con);
            int affectedRowCount = commandInstance.ExecuteNonQuery();
            FinalResultDisplay(affectedRowCount,UPDATION);

        }

        public static void PerfromDeletion()
        {
            DisplayAllStudent();
            int student_id = GetIdOfStudent();

            string query = $"Delete from student where sid={student_id}";
            commandInstance = new SqlCommand(query,con);
            int affectedRowCount = commandInstance.ExecuteNonQuery();
            FinalResultDisplay(affectedRowCount,DELETION);
        }

        public static void DisplayAllStudent()
        {
            string query = "select * from student";
            commandInstance = new SqlCommand(query,con);
            dataReader = commandInstance.ExecuteReader();

            Console.WriteLine("STUDENT ID | STUDENT NAME | STUDENT MARKS");
            while (dataReader.Read())
            {
                Console.WriteLine($"{dataReader["sid"]}   |  {dataReader["sname"]}  | {dataReader["marks"]} ");
            }
            dataReader.Close();
        }

        public static void FinalResultDisplay(int affectedRowCount,string OPERATION)
        {
            if (affectedRowCount > 0)
            {
                Console.WriteLine($"Data {OPERATION} successful.");
                DisplayAllStudent();
            }
            else
            {
                Console.WriteLine($"Cannot perform {OPERATION} of data.");
            }
        }


        public static int GetIdOfStudent()
        {

            Console.Write("Enter id of student you wish to Update record of ");
            string idOfStudent = Console.ReadLine();
            int finalId;
            Int32.TryParse(idOfStudent, out finalId);
            return finalId;
        }

    }
}
