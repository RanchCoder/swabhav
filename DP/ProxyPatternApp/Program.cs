using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyPatternApp.Model;
namespace ProxyPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountProxy a = new AccountProxy("NEW10001",1500,"NEW ACCOUNT");
            a.Deposit(500);
            Console.ReadLine();

        }
    }
}
