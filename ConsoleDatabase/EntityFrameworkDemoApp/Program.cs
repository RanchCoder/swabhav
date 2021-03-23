using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemoApp.Model;
namespace EntityFrameworkDemoApp
{
    class Program
    {
        static DemoDbContext db = new DemoDbContext();
        static void Main(string[] args)
        {
           //CreateEmployee();
           DeleteEmployee();
           //UpdateEmployee();
            Console.ReadLine();
        }

        private static void CreateEmployee()
        {
            Employee[] employees = { new Employee { Id = 101, Name = "Steven",Salary =16500 } };
            foreach(Employee employee in employees)
            {
                Employee employeeAdded = db.Employees.Add(employee);
                db.SaveChanges();
                Console.WriteLine($"Employee Added : id - {employeeAdded.Id} , name - {employeeAdded.Name}");
               
            }
        }

        public static void InsertEmployee(Employee employee)
        {
            Employee employeeAdded = db.Employees.Add(employee);
            
            db.SaveChanges();
            Console.WriteLine($"Employee Added : id - {employeeAdded.Id} , name - {employeeAdded.Name}");

        }

        public static void DeleteEmployee()
        {
            PrintAllEmployee();
           
            int id = GetEmployeeId();
            Employee employeeToBeDeleted = db.Employees.Where(emp => emp.Id == id).Select(emp => emp).FirstOrDefault();
            Employee deletedEmployee =  db.Employees.Remove(employeeToBeDeleted);
            Console.WriteLine($"Employee deleted : id - {deletedEmployee.Id} , name - {deletedEmployee.Name}");
            db.SaveChanges();
        }



        public static void UpdateEmployee()
        {

            PrintAllEmployee();

            int id = GetEmployeeId();
            Employee employeeToBeUpdated = db.Employees.Where(emp => emp.Id == id).Select(emp => emp).FirstOrDefault();

            try
            {
                employeeToBeUpdated.Name = "Roddrick";
                employeeToBeUpdated.Salary = 250000;
                db.SaveChanges();
                Console.WriteLine($"Employee record updated :id - {employeeToBeUpdated.Id} , name - {employeeToBeUpdated.Name}");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void PrintAllEmployee()
        {
            Console.WriteLine($" Id | Employee Name | Employee Salary");
            foreach(Employee employee in db.Employees)
            {
                Console.WriteLine($"{employee.Id}  | {employee.Name} | {employee.Salary}");
            }
        }

        public static int GetEmployeeId()
        {
            Console.Write($"Enter employee Id  : ");
            int id;
            Int32.TryParse(Console.ReadLine(),out id);
            return id;
        }

        
        
    }
}
