using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPatternApp.Model;

namespace StrategyPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Context currentContext = new Context(new OperationAdd());
            Console.WriteLine("Addition strategy : " + currentContext.ExecuteStrategy(1,2));

            Context currentContext2 = new Context(new OperationMultiply());
            Console.WriteLine("Multiplication strategy : " + currentContext.ExecuteStrategy(2, 2));

            Console.ReadLine();
        }
    }
}
