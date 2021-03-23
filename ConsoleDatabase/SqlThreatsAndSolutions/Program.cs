using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlThreatsAndSolutions
{
    class Program
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringProvider"].ConnectionString);
        static SqlCommand command;
        static SqlDataReader dataReader;
        static void Main(string[] args)
        {
            try
            {
                con.Open();
                //FetchDataWithoutInjection();

                //Console.WriteLine("Mallicious User Performs Transaction (1 = 1) \n");
                //FetchDataWithInjection();

                //Console.WriteLine("Fetch data for Non existing Student (false ID)");
                //FetchDataForNonExistingUser();

                Console.WriteLine("Fetch Data for Non Existing User (False Id) along with mallicious code");
                DataForNonExistingUserWithInjection();


            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            Console.ReadLine();
        }

        public static void FetchDataWithoutInjection()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(studentId));

        }

        public static void FetchDataWithInjection()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(studentId)+" OR 1 = 1");
        }

        public static void FetchDataForNonExistingUser()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(studentId));
        }

        public static void DataForNonExistingUserWithInjection()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(studentId) + "OR 1 = 1");
        }

        public static int GetStudentId()
        {
            Console.Write("Enter the user id : ");
            string userInput = Console.ReadLine();
            int studentId;
            Int32.TryParse(userInput,out studentId);
            return studentId;
        }

        public static string QueryToFetchStudentById(int studentId)
        {
            return $"select * from student where sid={studentId}";
        }

        public static void PerformQuery(string query)
        {
            command = new SqlCommand(query,con);
            dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Console.WriteLine($"Student ID : {dataReader["sid"]} | Student Name : {dataReader["sname"]} | Student Marks : {dataReader["marks"]}");
                }
            }
            else
            {
                Console.WriteLine("No Record Found.");
            }
        }
    }
}
