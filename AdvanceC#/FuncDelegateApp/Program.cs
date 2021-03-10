using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Case1();
            Case2();
            Case3();
            Console.ReadLine();
        }

        public static long AddNumbers(int num1,int num2)
        {
            Console.WriteLine("Inside named function");
            return (long)(num1 + num2);
        }

        public static void Case1()
        {
            Func<int,int,long> x;
            x = AddNumbers;
            Console.WriteLine($"Addition of two numbers : {x(10, 20)}");
        }

        public static void Case2()
        {
            Func<int,int,long> x;
            x = delegate (int num1,int num2)
            {
                Console.WriteLine("\nInside anonymous function");
                return (long)(num1 + num2);
            };

            Console.WriteLine("Addition of two numbers using anonymous function "+x(10,20));

        }


        public static void Case3()
        {
            Func<int, int, long> x;
            x = (int num1, int num2)=>
            {
                Console.WriteLine("\nInside lambda function");
                return (long)(num1 + num2);
            };

            Console.WriteLine("Addition of two numbers using lambda function " + x(10, 20));
        }

    }
}
