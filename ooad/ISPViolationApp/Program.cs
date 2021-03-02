using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPViolationApp.Model;
namespace ISPViolationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m1 = new Manager();
            Robot r1 = new Robot();

            PrintWorEatkData(m1);
            PrintEatData(r1);
            Console.ReadLine();
        }

        public static void PrintWorEatkData(IWorkEat instance)
        {
            instance.StartEat();
            instance.StopEat();
            instance.StartWork();
            instance.StopWork();
        }

       public static void PrintEatData(IWork instance)
        {
            instance.StartWork();
            instance.StopWork();
        }
    }
}
