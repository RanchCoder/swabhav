using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Programmer programmer1 = new Programmer(1,"vishal",1000.5f,new DateTime(1996,12,23));
            Console.WriteLine($"++++++++++++++ EMPLOYEE SUMMARY ++++++++++++++++");
            Console.WriteLine($"EMPLOYEE NAME               {programmer1.Name}" +
                              $"\nEMPLOYEE D.O.B             {programmer1.Date.Day}/{programmer1.Date.Month.ToString()}/" +
                                                              $"{programmer1.Date.Year}" +
                              $"\nEMPLOYEE SALARY            Rs.{programmer1.Salary}" +
                              $"\nEMPLOYEE SALARY WITH BONUS Rs.{programmer1.ProgrammerSalaryWithBonus()}");
            Console.ReadLine();
        }

        
    }
}
