using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPatternAccountApp.Model;

namespace BuilderPatternAccountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountBuilder accountBuilder = new AccountBuilder(12345);
            accountBuilder.AccountBalance = 5000;
            accountBuilder.AccountHolderName = "Vishal";
            accountBuilder.BranchName = "Sion";
            Account account = accountBuilder.CreateAccount();

            Console.WriteLine($"Account Number : {account.AccountNumber}" +
                $"\nAccount Holder Name : {account.AccountHolderName}" +
                $"\nAccount Balance : {account.AccountBalance}" +
                $"\nBranch Name : {account.BranchName}" +

                $"\nInterest Rate : {account.InterestRate}");
            Console.ReadLine();

        }
    }
}
