using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Duplicate_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<int, int> numbers = new Dictionary<int, int>();

            int[] arrayOfNumbers = { 1, 2, 3, 1, 31, 12, 2, 3 };
            for(int i = 0; i < arrayOfNumbers.Length; i++)
            {
                if (numbers.ContainsKey(arrayOfNumbers[i]))
                {
                    numbers[arrayOfNumbers[i]]++;
                }
                else
                {
                    numbers.Add(arrayOfNumbers[i],1);
                }
            }

            for(int i = 0; i < numbers.Count; i++)
            {
                if(numbers.ElementAt(i).Value > 1)
                {
                    Console.WriteLine($"element {numbers.ElementAt(i).Key} is repeating : {numbers.ElementAt(i).Value} times.");
                }
            }
            Console.ReadLine();
        }
    }
}
