using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHomeWork1App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Case7();
            Console.ReadLine();
        }

        public delegate void DSayAnything(string name);

        public static void SayHello(string name)
        {
            //says hello
            Console.WriteLine($"Hello : {name}");
        }

        public static void SayGoodBye(string name)
        {
            //says good bye
            Console.WriteLine($"Good bye : {name}");
        }

        public static bool Saysomething(string fname,string lastName)
        {
            return false;
        }

        public static bool EvenOrOdd(int num)
        {
            return num % 2 == 0;
        }

        public static void Case1()
        {

            Action<string> actionFunction = SayHello;
            actionFunction("Vishal");



            actionFunction("Singh");
           
        }


        public static void Case2()
        {
            Console.WriteLine("\nCase 2:\n");
            DSayAnything y;
            y = SayHello;
            y += SayGoodBye;
            y("xyz");
        }


        public static void Case3()
        {
            Console.WriteLine("\nCase 3:\n");
            MessageWizard(SayHello);
            MessageWizard(SayGoodBye);
        }


        public static void MessageWizard(DSayAnything fn)
        {
            Console.WriteLine("Inside Message Wizard");
            fn("champ");
            
        }

        public static void Case4()
        {
            Console.WriteLine("\nCase 4:\n");
            MessageWizard(delegate (string name)
            {
                Console.WriteLine("Anonymous delegate function");
                Console.WriteLine("Hello {0}....", name);

            });
        }

        public static void Case5()
        {
            Console.WriteLine("\nCase 5:\n");
            MessageWizard((n) =>
            {
                Console.WriteLine("Lambda");
                Console.WriteLine("Hello {0}....", n);

            });

        }

        public static void Case7()
        {
            Func<string, string, bool> messagePrinter;
            messagePrinter = Saysomething;
            Console.WriteLine(messagePrinter("Vishal","Singh"));
        }

        public static void Case8()
        {
            Predicate<int> numberChecker = EvenOrOdd;
            Console.WriteLine(numberChecker(10));
        }

        public static void CustomGreetingMessage(string personToBeGreeted)
        {
            Console.WriteLine($"hello {personToBeGreeted}");
        }
        public static void Case6()
        {
            MessageForCustomTesting(CustomGreetingMessage);
        }

        public static void MessageForCustomTesting(DSayAnything func)
        {
            Console.WriteLine($"Custom Message");
            func("Vishal is trying to something Different,May god guide him");
        }
    }
}
