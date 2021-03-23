using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PreparedStatementSolutionToInjection
{
    class Program
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PreparedStatementSolution"].ConnectionString);
        static SqlCommand command;
        static SqlDataReader dataReader;
        static void Main(string[] args)
        {
            try
            {
                con.Open();
                //Console.WriteLine("Fetching Student data based on Id using Prepared Statement and without Injection");
                //FetchDataWithoutInjection();

                //Console.WriteLine("fetching student data based on id using prepared statement and with injection");
                //FetchDataWithInjection();

                //Console.WriteLine("fetching student data using Prepared Statement for (False ID)");
                //FetchDataForNonExistingUser();

                Console.WriteLine("Fetch Data using Prepared Statement for Non Existing User (False Id) along with mallicious code");
                DataForNonExistingUserWithInjection();


            }
            catch (Exception e)
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
            PerformQuery(QueryToFetchStudentById(),studentId);

        }

        public static void FetchDataWithInjection()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(),studentId);
        }

        public static void FetchDataForNonExistingUser()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(),studentId);
        }

        public static void DataForNonExistingUserWithInjection()
        {
            int studentId = GetStudentId();
            PerformQuery(QueryToFetchStudentById(),studentId);
        }

        public static int GetStudentId()
        {
            Console.Write("Enter the user id : ");
            string userInput = Console.ReadLine();
            int studentId;
            Int32.TryParse(userInput, out studentId);
            return studentId;
        }

        public static string QueryToFetchStudentById()
        {
            return $"select * from student where sid=@studentId";
        }

        

        public static void PerformQuery(string query,int studentId)
        {
            command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@studentId",$"{studentId} OR 1 = 1");

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

