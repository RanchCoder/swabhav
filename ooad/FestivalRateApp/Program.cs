using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalRateApp.Model;
namespace FestivalRateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IFestivalRate dr = new DiwaliRate();
            FixedDeposit fd = new FixedDeposit(123,"Vishal Singh",10000,10000,dr,5);
            Console.WriteLine($"Name : {fd.AccountName}\nPrinciple Amount : {fd.Principle}\nRate of Intrest = {dr.GetIntrestRate()}" +
                $"\nAmount After {fd.Years} yrs will be Rs{fd.CalculateSimpleIntrest()}/-");
            Console.ReadLine();
        }
    }
}
