using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET_CRUD_OPERATION
{
    class Program
    {
        public static void PrintSetItems(SortedSet<int> set)
        {
            int counter = 0;
            foreach(int element in set)
            {
                Console.WriteLine($"{counter++}) {element}");
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; ;)
            {
                Console.WriteLine("hello");
            }
          
            //PrintSetItems(set);

            ////update the set
            //set.Add(1);
            //Console.WriteLine($"Printing set after updating the Set");
            //PrintSetItems(set);

            //set.Remove(10);
            //Console.WriteLine($"Printing set after deleting element from the Set");
            //PrintSetItems(set);

            Console.ReadLine();


        }
    }
}
