using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> name = args;

            var sortedName = name.OrderBy(x => x).Take(3);

            Console.WriteLine("Sorted Names are : ");
            foreach (string personName in sortedName)
            {
                Console.WriteLine(personName);
            }

            Console.WriteLine("\n\nNames starting with vowels");
            foreach (string personName in sortedName)
            {
                if (personName.StartsWith("a") || personName.StartsWith("e") || personName.StartsWith("i") || personName.StartsWith("o") || personName.StartsWith("u"))
                {
                    Console.WriteLine(personName);
                }
            }



            Console.ReadLine();
        }
    }
}
