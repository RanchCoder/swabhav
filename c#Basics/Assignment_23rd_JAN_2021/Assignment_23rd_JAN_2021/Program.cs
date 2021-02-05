using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_23rd_JAN_2021
{
    class ConvertUserInput
    {
        static void Main()
        {
            string arrayInput = Console.ReadLine();
            string[] charArray = arrayInput.Split(' ');
            int[] numericArray = new int[charArray.Length];

            //   TASK 1
            //   store the string input in the int array
            for (int i = 0; i < charArray.Length; i++)
            {
               
                numericArray[i] = int.Parse(charArray[i]);
            }

            //   TASK 2
            //   printing all the even numbers in array
            Console.WriteLine("Even numbers in array are :: ");
            for (int j = 0; j < numericArray.Length; j++)
            {
                Console.Write(numericArray[j] % 2 == 0 ? $"{numericArray[j]} " : "");
            }
            

            Console.ReadLine();
        }
    }
}
