using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTestApp.Model;
namespace SingletonPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService d1 = DataService.GetInstance();
            DataService d2 = DataService.GetInstance();

            Console.WriteLine(d1.GetHashCode());
            Console.WriteLine(d2.GetHashCode());

            d1.ProcessData();
            d2.ProcessData();
            Console.ReadLine();

        }
    }
}
