
using DelegateEmployeeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employeeA = new Employee("vishal",123,5000,5);

            Employee employeeB = new Employee("Lalchand", 124, 1000, 3);

            Employee employeeC = new Employee("Kapoorchand", 125, 3000, 2);

            Employee employeeD = new Employee("Suresh", 126, 4000, 6);

            Employee employeeE = new Employee("Ramesh", 127, 9000, 10);

            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employeeA);
            employeeList.Add(employeeB);
            employeeList.Add(employeeC);
            employeeList.Add(employeeD);
            employeeList.Add(employeeE);

            IsPromotable isPromotable = new IsPromotable(Promote);

            Employee.PromoteEmployee(employeeList,isPromotable);

            Console.ReadLine();
        }

        public static bool Promote(Employee employee)
        {
            if(employee.ExperienceOfEmployee >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
