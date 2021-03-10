using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractiseApp
{
    class Program
    {
        public delegate void DSayAnything(string name);
        static void Main(string[] args)
        {
            Case1();
            Case2();
            Case3();
            Console.ReadLine();
        }

        public static void GreetUser(string name)
        {
            Console.WriteLine("Inside named function");
            Console.WriteLine($"\nHello {name}");
        }

        public static void Case1()
        {
            DSayAnything x;
            x = GreetUser;
            x("Vishal");
        }

        public static void Case2()
        {
            DSayAnything x;
            x = delegate (string name)
            {
                Console.WriteLine("\nInside anonymous function");
                Console.WriteLine($"Hello again {name}");
            };

            x("Vishal");
        
        }

     
        public static void Case3()
        {
            DSayAnything x;
            x = (string name) =>
            {
                Console.WriteLine("\nInside lambda function");
                Console.WriteLine($"Hello for the third time {name}");
            };
            x("Vishal");
        }

    }
}
