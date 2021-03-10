using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorEventApp.Model;
namespace CalculatorEventApp
{
    class Program
    {
        static void Main(string[] args)
        {
           

                Calculator c = new Calculator();

            DCalcOperationAlert details = PrintAdddetails;
                c.AdditionCompleted += details;
                c.Add(2, 3);
            Console.ReadLine();
            }

        public static void PrintAdddetails(int x , int y , int result)
        {
            Console.WriteLine($"num 1 : {x} , num 2 : {y}");
            Console.WriteLine($"Result : {result}");
        }
    }
}
