using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Behaviour_App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Child instanceOfChild = new Child(200);
            Console.WriteLine(instanceOfChild.GetValue());

            Console.ReadLine();
        }
    }
}
