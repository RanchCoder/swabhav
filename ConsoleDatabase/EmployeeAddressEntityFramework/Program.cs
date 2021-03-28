using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAddressEntityFramework.Model;
namespace EmployeeAddressEntityFramework
{
    class Program
    {
        public static EmpAddressDBContext db = new EmpAddressDBContext();
        static void Main(string[] args)
        {
            //CreateTable();
            // MaximumSalary();
            // DesignationWiseEmployee();
            //clerkAndSalary();
            //EmployeeAddressIfAny();
            //EmployeeOfMumbai();
            EmployeeOfMumbaiOrDelhi();
            Console.ReadLine();
        }

        public static void CreateTable()
        {
            Employee emp1 = new Employee() { EmpId = 1, Name = "vishal", Salary = 20000, Designation = "programmer" };
            Employee emp2 = new Employee() { EmpId = 2, Name = "Rajesh", Salary = 20000, Designation = "programmer" };
            Employee emp3 = new Employee() { EmpId = 3, Name = "Mayank", Salary = 20000, Designation = "programmer" };
            Employee emp4 = new Employee() { EmpId = 4, Name = "Dixit", Salary = 20000, Designation = "programmer" };
            Employee emp5 = new Employee() { EmpId = 5, Name = "Ayush", Salary = 20000, Designation = "programmer" };

            Address address1 = new Address() { Id = 1, Detail = "mumbai" };
            Address address2 = new Address() { Id = 2, Detail = "Pune" };
            Address address3 = new Address() { Id = 3, Detail = "Delhi" };

            Address address4 = new Address() { Id = 4, Detail = "Chennai" };
            Address address5 = new Address() { Id = 5, Detail = "Shillong" };
            Address address6 = new Address() { Id = 6, Detail = "Darjeeling" };
            Address address7 = new Address() { Id = 7, Detail = "kochi" };
            Address address8 = new Address() { Id = 8, Detail = "Mumbai" };
            Address address9 = new Address() { Id = 9, Detail = "Pune" };




            emp1.EmpAddress.Add(address1);
            emp1.EmpAddress.Add(address2);
            emp2.EmpAddress.Add(address3);
            emp3.EmpAddress.Add(address4);
            emp4.EmpAddress.Add(address5);
            emp5.EmpAddress.Add(address9);

            emp3.EmpAddress.Add(address6);
            emp4.EmpAddress.Add(address7);
            emp2.EmpAddress.Add(address8);

            db.Employees.Add(emp1);
            db.Employees.Add(emp2);
            db.Employees.Add(emp3);
            db.Employees.Add(emp4);
            db.Employees.Add(emp5);

            db.SaveChanges();
            Console.WriteLine("Tables Created");


        }

        public static void MaximumSalary()
        {
            var result = db.Employees.OrderByDescending(x => x.Salary).Take(3).ToList();
            foreach (var employee in result)
            {
                Console.WriteLine($"Employeee Name : {employee.Name} | Employee Salary : {employee.Salary}");
            }
        }

        public static void DesignationWiseEmployee()
        {
            var result = db.Employees.OrderBy(x => x.Designation).ToList();
            foreach (var employee in result)
            {
                Console.WriteLine($"Employeee Name : {employee.Name} | Employee Designation : {employee.Designation}");
            }

        }

        public static void EmployeeAddressIfAny()
        {

            var result = db.Employees.Join(db.Addresses,
                employees => employees.EmpId,
                addresses => addresses.Emp.EmpId,
                (employee, address) => new { name = employee.Name, address = address.Detail });
            foreach (var employee in result)
            {
                Console.WriteLine($"Employeee Name : {employee.name} | Employee address : {employee.address}");
            }
        }

        public static void clerkAndSalary()
        {
            Console.WriteLine($"Employee who is clerk and his salary > 5000");
            var result = db.Employees.Where(x => x.Designation == "clerk" && x.Salary >= 5000).ToList();
            foreach (var employee in result)
            {
                Console.WriteLine($"Employeee Name : {employee.Name} | Employee Designation : {employee.Designation} | employee Salary : {employee.Salary}");
            }

        }

        public static void EmployeeOfMumbai()
        {
            Console.WriteLine("employee of mumbai city");
            var MumbaiEmployee = db.Employees.Join(db.Addresses,
                employee => employee.EmpId,
                address => address.Emp.EmpId,
                (employee, address) => new
                {
                    name = employee.Name,
                    address = address.Detail,
                }).Where(x => x.address == "mumbai");

            foreach (var employee in MumbaiEmployee)
            {
                Console.WriteLine($"Employeee Name : {employee.name} | Employee address : {employee.address} |");
            }
        }

        public static void EmployeeOfMumbaiOrDelhi()
        {
            Console.WriteLine("employee of mumbai city or delhi");
            var MumbaiEmployee = db.Employees.Join(db.Addresses,
                employee => employee.EmpId,
                address => address.Emp.EmpId,
                (employee, address) => new
                {
                    name = employee.Name,
                    address = address.Detail,
                }).Where(x => x.address == "mumbai" || x.address == "delhi");

            foreach (var employee in MumbaiEmployee)
            {
                Console.WriteLine($"Employeee Name : {employee.name} | Employee address : {employee.address} |");
            }
        }

    }
}
