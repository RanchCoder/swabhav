using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternAccountApp.Model
{
    class Account
    {
        private int _accountNumber;
        private string _accountHolderName;
        private double _accountBalance;
        private string _branchName;
        private double _interestRate;

        public int AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string AccountHolderName { get => _accountHolderName; set => _accountHolderName = value; }
        public double AccountBalance { get => _accountBalance; set => _accountBalance = value; }
        public string BranchName { get => _branchName; set => _branchName = value; }
        public double InterestRate { get => _interestRate; set => _interestRate = value; }
    }
}
