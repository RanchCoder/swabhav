using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPatternApp.Model;
namespace ObserverPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account(12345,"Vishal",5000f);
           
            account1.AddListener(new SmsListener());

            account1.AddListener(new EmailListener());
            account1.Deposit(500);
            account1.Withdraw(1000);
            Console.ReadLine();
        }
    }
}
