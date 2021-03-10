using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternApp.Model
{
    class Account
    {
        private int _accountNumber;
        private string _accountHolderName;
        private float _accountBalance;
        private const string MESSAGE_FOR_WITHDRAWL = "Withdrawl";

        private const string MESSAGE_FOR_DEPOSIT = "Deposit";
        List<IListener> listOfListener = new List<IListener>();

        public Account(int accountNumber, string accountHolderName,float accountBalance)
        {
            _accountNumber = accountNumber;
            _accountHolderName = accountHolderName;
            _accountBalance = accountBalance;
        }

        public int AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string AccountHolderName { get => _accountHolderName; set => _accountHolderName = value; }
        public float AccountBalance { get => _accountBalance; set => _accountBalance = value; }

        public void Withdraw(float amount)
        {
            AccountBalance -= amount;
            
            NotifyListener(MESSAGE_FOR_WITHDRAWL);
        }

        public void Deposit(float amount)
        {
            AccountBalance += amount;
            NotifyListener(MESSAGE_FOR_DEPOSIT);
        }

        public void AddListener(IListener listener)
        {
            listOfListener.Add(listener);
        }

        public void NotifyListener(string message)
        {
            

                foreach (IListener listener in listOfListener)
                {
                    listener.Update(this,message);
                }
            
            
        }

    }
}
