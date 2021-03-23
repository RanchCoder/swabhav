using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TransactionalApplication
{

    class Program
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TransactionalString"].ConnectionString);
        static SqlCommand cmd;
        static SqlTransaction transaction;
        static SqlDataReader dataReader;
        static void Main(string[] args)
        {
            try
            {
                con.Open();
                transaction = con.BeginTransaction();
                DisplayData();
                Console.WriteLine("\nPerforming transaction");
                PerformTransaction();

                transaction.Commit();
                Console.WriteLine("\nData After Transaction ");
                DisplayData();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                con.Close();
            }
            Console.ReadLine();
        }
        public static void PerformTransaction()
        {
            int amountOfTransaction =  GetTransactionAmount();
            cmd = new SqlCommand($"Update tbl_merchant set balance = (balance + {amountOfTransaction})",con,transaction);
            cmd.ExecuteNonQuery();
            
            cmd = new SqlCommand($"Update tbl_shopcustomer set balance = (balance - {amountOfTransaction})", con, transaction);
            cmd.ExecuteNonQuery();
           
        }

        public static int GetTransactionAmount()
        {
            Console.Write("\nEnter the transaction Amount : ");
            string amountInput = Console.ReadLine();
            int finalAmount;
            Int32.TryParse(amountInput,out finalAmount);
            return finalAmount;
        }

        public static void DisplayData()
        {
            Console.WriteLine("\nMerchant Data");
            cmd = new SqlCommand("select * from tbl_merchant", con,transaction);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine($"\nMerchant Name : {dataReader["merchant_name"]} | Merchant Balance : {dataReader["balance"]}");
            }

            dataReader.Close();

            Console.WriteLine("\nCustomer Data");
            cmd = new SqlCommand("select * from tbl_shopCustomer", con,transaction);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine($"Customer Name : {dataReader["customer_name"]} | Customer Balance : {dataReader["balance"]}");
            }
            dataReader.Close();
        }
    }
}
