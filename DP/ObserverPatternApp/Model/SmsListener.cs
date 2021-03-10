using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternApp.Model
{
    class SmsListener : IListener
    {
        void IListener.Update(Account account,string message)
        {
            Console.WriteLine($"\n\nSMS UPDATE after {message}");
            Console.Write($"\nAccount Number : {account.AccountNumber.ToString().Substring(0,2)}****" +
                $"\tAccount Name : {account.AccountHolderName}" +
                $"\tAccount Balance : {account.AccountBalance}");
        }
    }
}
