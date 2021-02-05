using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_App.model
{
    class Account
    {
        static int acc_number_counter= 1000;
        private int transactionPerformed = 0;
        private string accountNumber;
        bool isWithdrawlPossible = false;
        private string accountHolderName;
        private float balance;

        const float MIN_BALANCE = 500;

        public string AccountHolderName { get => accountHolderName; set => accountHolderName = value; }
        public float Balance { get => balance; set => balance = value; }
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }

        public Account(string accountHolderName,float balance)
        {

            accountNumber = "SBI" + acc_number_counter;
            this.accountHolderName = accountHolderName;
            this.balance = balance;
            acc_number_counter += 1;
        }

        

        public bool Withdraw(float amount)
        {
            if(balance <= MIN_BALANCE)
            {
                
                return isWithdrawlPossible;
            }
            isWithdrawlPossible = true;
            this.balance -= amount;
            transactionPerformed += 1;
            return isWithdrawlPossible;
        }


        public bool Deposit(float amount)
        {
            if(amount < 1)
            {
               
                return isWithdrawlPossible;
            }
            isWithdrawlPossible = true;
            this.balance += amount;
            transactionPerformed += 1;
            return isWithdrawlPossible;
        }

        public int GetTransactionPerformed()
        {
            return this.transactionPerformed;
        }
        
    }
}
