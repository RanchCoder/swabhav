using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternAccountApp.Model
{
    class AccountBuilder
    {
        private int _accountNumber;
        private string _accountHolderName;
        private double _accountBalance;
        private string _branchName;
        private double _interestRate;

        public AccountBuilder(int accountNumber)
        {
            this._accountNumber = accountNumber;
        }

        public string AccountHolderName { get => _accountHolderName; set => _accountHolderName = value; }
        public double AccountBalance { get => _accountBalance; set => _accountBalance = value; }
        public string BranchName { get => _branchName; set => _branchName = value; }
        public double InterestRate { get => _interestRate; set => _interestRate = value; }
       
        public Account CreateAccount()
        {
            Account account = new Account();
            account.AccountNumber = this._accountNumber;
            account.AccountHolderName = this.AccountHolderName;
            account.AccountBalance = this.AccountBalance;
            account.BranchName = this.BranchName;
            account.InterestRate = this.InterestRate;
            return account;
        }
    }
}
