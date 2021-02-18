using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App_With_Manager_Analyst_Module
{
    class Program
    {
        public static void PrintEmployeeInfo(Employee employee,float salaryWithBonus)
        {
            Console.WriteLine($"\n\n\n++++++++++++++ EMPLOYEE SUMMARY ++++++++++++++++");
            Console.WriteLine($"");
            Console.WriteLine($"EMPLOYEE NAME                   {employee.Name}" +
                              $"\nEMPLOYEE DESIGNATION            {employee.Designation}" +

                              $"\nEMPLOYEE D.O.B                {employee.Date.Day}/{employee.Date.Month.ToString()}/" +
                                                               $"{employee.Date.Year}" +
                              $"\nEMPLOYEE SALARY                Rs.{employee.Salary}" +
                              $"\nEMPLOYEE SALARY WITH BONUS     Rs.{salaryWithBonus}" +
                              $"\nHome Rental Allowance          Rs.{employee.HouseRentAllowance}" +
                              $"\nDearness Allowance             Rs.{employee.DearnessAllowance}" +
                              $"\nTravel Allowance               Rs.{employee.TravelAllowance}"+
                              $"\nSalary (HRA + DA + TA)         Rs.{employee.ComputeSalaryWithAllowance()}");


        }
        static void Main(string[] args)
        {
            Manager manager1 = new Manager(1, "vishal", 100000.5f, new DateTime(1996, 12, 23), "Manager");
            PrintEmployeeInfo(manager1,manager1.SalaryWithBonus());

            if(manager1 is Employee)
            {
                Console.WriteLine("Yes it is an instance");
            }

            Analyst analyst1 = new Analyst(2,"Tom",25000f,new DateTime(1990,1,12),"Analyst");
            PrintEmployeeInfo(analyst1,analyst1.SalaryWithBonus());
            Console.ReadLine();

        }
    }
}
