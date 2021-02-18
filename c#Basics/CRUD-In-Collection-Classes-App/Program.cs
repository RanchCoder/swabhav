using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_In_Collection_Classes_App
{
    class Program
    {
        public static void PrintListData(List<int> listOfElement)
        {
            int counter = 1;
            Console.WriteLine("Printing Elements in the LIST");
            foreach(int element in listOfElement)
            {
                Console.WriteLine($"{counter++}) {element}");
            }
        }
        
        static void Main(string[] args)
        {
            //CRUD of LIST
            //Create
            List<int> listOfInteger = new List<int>();
            listOfInteger.Add(11);
            listOfInteger.Add(21);
            listOfInteger.Add(31);
            listOfInteger.Add(41);
            listOfInteger.Add(51);

            //Read
            PrintListData(listOfInteger);

            //Update
            listOfInteger.Insert(1, 200);
            Console.WriteLine("\nPrinting List after Update");
            PrintListData(listOfInteger);
            //Delete
            listOfInteger.RemoveAt(4);
            Console.WriteLine("\nPrinting List after Delete");
            PrintListData(listOfInteger);

            Console.ReadLine();

        }
    }
}
