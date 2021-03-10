using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternApp.Model
{
    class AccountProxy : Account
    {
      public AccountProxy(string accountName,double balance, string accountNumber) : base(accountName, balance, accountNumber) { }

      public void Deposit(int amount)
        {
            Console.WriteLine("Before Deposit Date time : "+ DateTime.Now);
            Console.WriteLine("Balance before depositing : " + Balance);
            base.Deposit(amount);
            Console.WriteLine("balance after depositing : " + Balance);
            Console.WriteLine("After depositing date time : " + DateTime.Now);
        }
    }
}
