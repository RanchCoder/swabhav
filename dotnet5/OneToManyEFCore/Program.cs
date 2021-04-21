using OneToManyEFCore.DBContext;
using System;
using System.Collections.Generic;
using OneToManyEFCore.Models;
using System.Linq;

namespace OneToManyEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            pg.PrintEmployees(employeeDBContext.Employees.ToList());
            pg.PrintDepartment(employeeDBContext.Department.ToList());
            Console.ReadLine();
        }

        public void PrintEmployees(List<Employee> employees)
        {
            Console.WriteLine("Employee ID     | Employee Name  | Employee Designation   |  Employee Salary ");
            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Designtion} | {employee.Designtion} | {employee.Salary}");
            }
        }

        public void PrintDepartment(List<Department> departments)
        {
            Console.WriteLine("Department Name  | Department Location ");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} | {department.Location}");
            }
        }
    }
}
