using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDataFetcher employeeDataFetcher = new EmployeeDataFetcher();
            employeeDataFetcher.OnProcessingComplete += PrintContentOfUrlData;
            employeeDataFetcher.ProcessData();
            Console.ReadLine();
        }

        public static void PrintContentOfUrlData(string content)
        {
            Console.WriteLine(content);
        }
    }
}
