using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employeeList = new List<Employee>() {

                new Employee(1,"vishal",10000,"programmer"),
                new Employee(2,"prem",54000,"manager"),
                new Employee(3,"Shashank",15000,"CTO")
            
            };

            var managerEmployees = employeeList.Where(x => x.Designation == "manager");
            foreach(Employee employee in managerEmployees)
            {
                Console.WriteLine($"Employee name : {employee.Name} | Employee salary : {employee.Salary} | Employee Designation : {employee.Designation}");
            }

            Console.WriteLine("\nTop three salary ");
            var topThreeEmployee = employeeList.OrderByDescending(x => x.Salary).Take(3);
            foreach (Employee employee in topThreeEmployee)
            {
                Console.WriteLine($"Employee name : {employee.Name} | Employee salary : {employee.Salary} | Employee Designation : {employee.Designation}");
            }

            Console.WriteLine("\nEmployee with salary 50000 ");
            var salaryGreaterEmployee = employeeList.Where(x => (x.Salary > 50000));
            foreach (Employee employee in salaryGreaterEmployee)
            {
                Console.WriteLine($"Employee name : {employee.Name} | Employee salary : {employee.Salary} | Employee Designation : {employee.Designation}");
            }


            Console.ReadLine();
        }
    }
}
