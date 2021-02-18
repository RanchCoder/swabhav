using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_App_Abstraction
{
    [Serializable]
    abstract class Account
    {
        private int accountNumber;
        private string accountHolderName;
        private float accountBalance;
        private int transactionCounter;

        public Account(int accountNumber,string accountHolderName,float accountBalance)
        {
            this.accountNumber = accountNumber;
            this.accountHolderName = accountHolderName;
            this.accountBalance = accountBalance;
        }

        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string AccountHolderName { get => accountHolderName; set => accountHolderName = value; }
        public float AccountBalance { get => accountBalance; set => accountBalance = value; }
        public int TransactionCounter { get => transactionCounter; set => transactionCounter = value; }

        public bool Deposit(float amount)
        {
            if(amount >= 1)
            {
                this.transactionCounter += 1;
                this.accountBalance += amount;
                return true;
            }
            return false;
        }
        public abstract bool Withdraw(float amount);
    }
}
