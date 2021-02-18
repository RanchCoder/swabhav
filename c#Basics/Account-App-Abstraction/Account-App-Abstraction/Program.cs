using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Account_App_Abstraction
{
    [Serializable]
    class Program
    {
        public static bool isWithdraw = false;
        
        public static void PrintTransactionRecord(bool response,Account account,bool transactionType)
        {
            if(transactionType == true)
            {
                if (response == true)
                {
                    Console.WriteLine($"Transaction successful for Withdrawl" +
                        $"\nCurrent Balance : {account.AccountBalance} ");
                }
                else
                {
                    Console.WriteLine($"Transaction unsuccessful, account balance is too low for withdrawl");
                }
                isWithdraw = false;
            }
            else
            {
                Console.WriteLine($"Transaction successful for Deposit" +
                        $"\nCurrent Balance : {account.AccountBalance} ");
            }
            
        }

        public static void PrintAccountDetail(Account account)
        {
            Console.WriteLine($"Account Details" +
                $"\nAccount Number : {account.AccountNumber}" +
                $"\nAccount Holder Name : {account.AccountHolderName}" +
                $"\nAccount Balance : {account.AccountBalance}" +
                $"\nAccount Transaction History : {account.TransactionCounter} no of Transaction performed");
        }
        static void Main(string[] args)
        {
            Account account1 = new Current(1,"Vishal",1500);
            Account account2 = new Current(2,"Ankit",2000);

            FileStream fs = new FileStream(@"D:\FileOperationInC#\serializedObjectData.txt",FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs,account1);
            
            account1.TransactionCounter = 0;
            bool account1Withdraw = account1.Withdraw(500);
            
            

            PrintTransactionRecord(account1Withdraw, account1, isWithdraw = true);

            bool account1Withdraw2 = account1.Withdraw(500);



            PrintTransactionRecord(account1Withdraw2, account1, isWithdraw = true);

            bool account1Deposit = account1.Deposit(500);

            PrintTransactionRecord(account1Withdraw, account1, isWithdraw = false);
            PrintAccountDetail(account1);
            fs.Close(); // close file stream
            Console.ReadLine();
        }
    }
}
