using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_In_Dictonary_Generic
{
    class Program
    {
        public static void PrintDictionaryData(Dictionary<string,int> dictonaryOfKeyValue)
        {
            int counter = 1;
            Console.WriteLine("Printing Elements in the Dictonary");
            foreach (KeyValuePair<string, int> entry in dictonaryOfKeyValue)
            {
                Console.WriteLine($"{counter++}){entry.Key} - {entry.Value}");
            }
        }

        static void Main(string[] args)
        {
            //CRUD of LIST
            //Create
            Dictionary<string,int> dictonaryOfKeyValue = new Dictionary<string,int>();
            dictonaryOfKeyValue.Add("vishal",1);
            dictonaryOfKeyValue.Add("prem", 2);
            dictonaryOfKeyValue.Add("rajesh", 3);
            dictonaryOfKeyValue.Add("shiven", 4);
            dictonaryOfKeyValue.Add("Rudra", 5);

            //Read
            PrintDictionaryData(dictonaryOfKeyValue);

            //Update
            dictonaryOfKeyValue["vishal"]++;

            Console.WriteLine("\nPrinting List after Update");
            PrintDictionaryData(dictonaryOfKeyValue);
            //Delete
            dictonaryOfKeyValue.Remove("Rudra");
            
            Console.WriteLine("\nPrinting List after Delete");
            PrintDictionaryData(dictonaryOfKeyValue);

            Console.ReadLine();

        }
    }
}
