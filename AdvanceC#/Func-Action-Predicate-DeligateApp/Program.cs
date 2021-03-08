using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Action_Predicate_DeligateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int, int> AdditionOperation = (int x,int y ,int z)=> x + y + z;
            Func<int, int, int> SubtractionOperation = (int x, int y) => (x > y) ? x - y : y - x;
            Action<int, int> MultiplicationOperation = (int x, int y) => Console.WriteLine($"Muliplication operation of {x} * {y}: {(x * y)}");
            Predicate<int> IsNumberGreaterThanTen = (int x) => x > 10;

            Console.WriteLine("Addition of 10,20,30 : "+AdditionOperation.Invoke(10,20,30));
            Console.WriteLine("Subtraction of 20 from 40 : " + SubtractionOperation.Invoke(20, 40));
            Console.WriteLine("Is 54 > 10 : " + IsNumberGreaterThanTen(54));
            MultiplicationOperation.Invoke(143,54);
            Console.ReadLine();

        }

        


    }
}
