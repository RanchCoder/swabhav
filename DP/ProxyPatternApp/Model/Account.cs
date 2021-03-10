using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ProxyPatternApp.Model
{
    class Account
    {
        private string _accountName;
        private double _balance;
        private string _accountNumber;

        public Account(string accountName,double balance)
        {
            _accountName = accountName;
            _balance = balance;
        }

        

        public Account(string accountName, double balance, string accountNumber)
        {
            _accountName = accountName;
            _balance = balance;
            _accountNumber = accountNumber;
        }

        public string AccountName { get => _accountName; set => _accountName = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }

        public void Deposit(int amount)
        {
            Thread.Sleep(1000);
            _balance += amount;
        }



    }
}
