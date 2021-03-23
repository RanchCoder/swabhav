using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneToOneEntityFrameworkApp.Model;

namespace OneToOneEntityFrameworkApp
{
    class Program
    {
       public static SwabhavDBContext db = new SwabhavDBContext();
       public static void Main(string[] args)
        {
            var deptSales = new Department { DeptId = 1, Name = "Sales", Location = "London" };
            var deptFinance = new Department { DeptId = 2, Name = "Finance", Location = "dubai" };

            var employee1 = new Employee { EmpId = 1, Name = "vishal", Salary = 15000 };

            var employee2 = new Employee { EmpId = 2, Name = "shiven", Salary = 23000 };
            var employee3 = new Employee { EmpId = 3, Name = "Ricotech", Salary = 42000 };
            var employee4 = new Employee { EmpId = 4, Name = "Novak", Salary = 51000 };
            var employee5 = new Employee { EmpId = 5, Name = "zeeshan", Salary = 14000 };

            employee1.Dept = deptSales;
            employee2.Dept = deptFinance;
            employee3.Dept = deptSales;
            employee4.Dept = deptFinance;
            employee5.Dept = deptSales;

            deptSales.DeptEmployees.Add(employee1);
            deptSales.DeptEmployees.Add(employee3);
            deptSales.DeptEmployees.Add(employee5);

            deptFinance.DeptEmployees.Add(employee2);

            deptFinance.DeptEmployees.Add(employee4);
            try
            {
                db.Departments.Add(deptSales);
                db.Departments.Add(deptFinance);

                db.SaveChanges();
                Console.WriteLine("Changes made, check the database");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }
}
