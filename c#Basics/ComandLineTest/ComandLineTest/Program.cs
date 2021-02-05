using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandLineTest
{
    class Program
    {
        public static void GetAllPrimeNumbers(int[] numberArray)
        {
            bool flag = false;
            Console.WriteLine("Prime numbers are");
            for(int i = 0; i < numberArray.Length; i++)
            {
                for(int j = 2; j < numberArray[i]/ 2; j++)
                {
                    if(numberArray[i] % j == 0)
                    {

                        flag = true;
                    }

                }
                if(flag == false)
                {
                    Console.WriteLine(numberArray[i]);
                }
            }


        }

        public static void PrintArray(int[] arr)
        {
            Console.WriteLine("Printing all other numbers ");
            for(int i = 0; i <= arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static void GetAllEvenNumbers(int[] numberArray)
        {
            Console.WriteLine("Even numbers are");
            for (int i = 0; i < numberArray.Length; i++)
            {
                if(numberArray[i] % 2 == 0)
                {
                    Console.Write($"{numberArray[i]} ");
                }
            }
            
        }

        public static void GetAllOddNumbers(int[] numberArray)
        {
            Console.WriteLine("Odd numbers are");
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] % 2 != 0)
                {
                    Console.Write($"{numberArray[i]} ");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            string requiredOperation = args[args.Length - 1];
            
            //Console.WriteLine(requiredOperation);

            int[] numberArray = new int[args.Length - 1];
            for (int i = 0; i < args.Length - 1; i++)
            {
                numberArray[i] = int.Parse(args[i]);
            }
            switch (requiredOperation)
            {
                case "p": GetAllPrimeNumbers(numberArray); break;
                case "e": GetAllEvenNumbers(numberArray);break;
                case "o": GetAllOddNumbers(numberArray);break;
                default: PrintArray(numberArray);break;
            }

            Console.ReadLine();
        }
    }
}
