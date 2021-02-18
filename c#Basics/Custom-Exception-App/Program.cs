using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Exception_App
{
    class Program
    {
        public static void CheckDivisor(int num) {

            if (num == 0)
            {
                throw (new CustomExceptionForDivisionByZero("Cannot divide by zero"));
            }

        }
        public static void IsNumberNegative(int num)
        {
            if (num < 0)
            {
                throw (new CustomExceptionForNegativeNumber("Number is negative"));
            }
        }

        public static void CheckForString(string num)
        {
            if(num is string)
            {
                throw new CustomExceptionForString("Number is not of type string");
            }
        }

        public  static void M1() throw Exception{ 

        }
        static void Main(string[] args)
        {
            try
            {
                int a = Int32.Parse(args[0]);
                int b = Int32.Parse(args[1]);
                int c = a / b;
               
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"{ex.GetType()} \n" + ex.Message + "\n "+ ex.StackTrace);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }

    class CustomExceptionForDivisionByZero : Exception {

        public CustomExceptionForDivisionByZero(string message) : base(message) { }

    }

    class CustomExceptionForNegativeNumber : Exception
    {
        public CustomExceptionForNegativeNumber(string message) : base(message) { }
    }

    class CustomExceptionForString : Exception {
       public CustomExceptionForString(string message): base(message){}
    }
}

