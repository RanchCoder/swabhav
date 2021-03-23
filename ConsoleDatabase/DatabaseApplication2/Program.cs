using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCommand command_obj;
            SqlDataReader dataReader;
            SqlTransaction transaction_obj;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dynamicConnectionString"].ConnectionString;
            Console.WriteLine(connectionString);
            SqlConnection con = new SqlConnection(connectionString);
            try {
                con.Open();
                Console.WriteLine("Connection Sucessfull...!\nConnectionString is : " + con.ConnectionString);
                Console.WriteLine("Connection Timeout :" + con.ConnectionTimeout);
                Console.WriteLine("Connected Database :" + con.Database);
                Console.WriteLine("Connected DataSource :" + con.DataSource);
                Console.WriteLine("Credential :" + con.Credential);
                Console.WriteLine("Schema information of Datasource : " + con.GetSchema());
                Console.WriteLine("the state of the SqlConnection :" + con.State);
                Console.WriteLine("the version of the instance of SQL Server : " + con.ServerVersion);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //try
            //{
            //    if(connection_obj.State == ConnectionState.Closed)
            //    {
            //        connection_obj.Open();
            //    }
            //    command_obj = new SqlCommand("Select * from employee",connection_obj);
            //    connection_obj.BeginTransaction();
            //    dataReader = command_obj.ExecuteReader();

            //    while (dataReader.Read())
            //    {
            //        Console.WriteLine($"Employee Name : {dataReader["Ename"]} -- Employee Salary : {dataReader["SAL"]}");

            //    }

            //}catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    if(connection_obj.State == ConnectionState.Open)
            //    {
            //        connection_obj.Close();
            //    }
            //}
            Console.ReadLine();
        }
    }
}
