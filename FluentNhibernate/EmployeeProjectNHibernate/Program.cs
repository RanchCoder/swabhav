using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjectNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {

            //var salesDept = new Department { DeptName = "Sales", Location = "Pune" };
            //var empForSales = new Employee { Name = "Markhand", Designation = "manager", Salary = 100000 };
            //InsertRecords(salesDept,empForSales);
            // FindEmployeeByDepartmentId(DepartmentCode.FINANCE);
            //SortEmployeeByDepartmentName();
            //HighestSalaryInEachDepartment();
            // DepartmentWithMaxEmployees();
            EmployeesInMumbaiBranch();
            Console.ReadLine();
           
        }

        public static void EmployeesInMumbaiBranch()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var departmentEmployees = session.Query<Department>().Join(session.Query<Employee>(),
                        department => department.Id,
                        employee => employee.Department.Id,
                        (department, employee) => new
                        {
                            departmentId = department.Id,
                            employeeName = employee.Name,
                            employeeDesignation = employee.Designation,
                            employeeDepartment = department.DeptName,
                            employeeSalary = employee.Salary,
                            departmentLocation = department.Location
                        }).Where(x=>x.departmentLocation == "Mumbai");
                    Console.WriteLine($"Displaying Employee working in mumbai Branch");
                    foreach (var employeeData in departmentEmployees)
                    {
                        Console.WriteLine($"\nEmployee Name : {employeeData.employeeName} | Employee Designation : {employeeData.employeeDesignation}" +
                            $" | Employee Department : {employeeData.employeeDepartment}" +
                            $" | Employee Salary : {employeeData.employeeSalary}" +
                            $"| Location : {employeeData.departmentLocation}");
                    }
                }
            }
        }
        public static void DepartmentWithMaxEmployees()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var departmentEmployees = session.Query<Department>().GroupJoin(session.Query<Employee>(),
                       department => department.Id,
                       employee => employee.Department.Id,
                       (department, employee) => new
                       {
                           departmentId = department.Id,
                           employeeDepartment = department.DeptName,
                           employeeCount = employee.Count()
                       }) ;

                    Console.WriteLine($"Displaying employee By count in each department");
                    foreach (var departmentEmployee in departmentEmployees)
                    {
                        Console.WriteLine($" Department Id : {departmentEmployee.departmentId} | Department Name : {departmentEmployee.employeeDepartment} | Total Employees : {departmentEmployee.employeeCount}");
                    }
                }
            }
        }
        public static void HighestSalaryInEachDepartment()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var departmentEmployees = session.Query<Department>().GroupJoin(session.Query<Employee>(),
                        department => department.Id,
                        employee => employee.Department.Id,
                        (department, employee) => new
                        {
                            departmentId = department.Id,
                            employeeDepartment = department.DeptName,
                            employeeSalary = employee.Max(x=>x.Salary),
                        });

                    Console.WriteLine($"Displaying Highest salary in each department");
                    foreach(var departmentEmployee in departmentEmployees)
                    {
                        Console.WriteLine($"Department Id : {departmentEmployee.departmentId} | department Name : {departmentEmployee.employeeDepartment} | Salary : {departmentEmployee.employeeSalary}");
                    }
                }
            }
        }
        public static void  SortEmployeeByDepartmentName()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var departmentEmployees = session.Query<Department>().Join(session.Query<Employee>(),
                        department => department.Id,
                        employee => employee.Department.Id,
                        (department, employee) => new
                        {
                            departmentId = department.Id,
                            employeeName = employee.Name,
                            employeeDesignation = employee.Designation,
                            employeeDepartment = department.DeptName,
                            employeeSalary = employee.Salary
                        }).OrderBy(x=>x.employeeDepartment);
                    Console.WriteLine($"Displaying Employee by department in sorted order");
                    foreach (var employeeData in departmentEmployees)
                    {
                        Console.WriteLine($"\nEmployee Name : {employeeData.employeeName} | Employee Designation : {employeeData.employeeDesignation}" +
                            $" | Employee Department : {employeeData.employeeDepartment}" +
                            $" | Employee Salary : {employeeData.employeeSalary}");
                    }
                }
            }
        }

        public static void FindEmployeeByDepartmentId(DepartmentCode code)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var departmentEmployees = session.Query<Department>().Join(session.Query<Employee>(),
                        department => department.Id,
                        employee => employee.Department.Id,
                        (department, employee) => new
                        {
                            departmentId = department.Id,
                            employeeName = employee.Name,
                            employeeDesignation = employee.Designation,
                            employeeDepartment = department.DeptName,
                            employeeSalary = employee.Salary
                        }).Where(x=>x.departmentId == (int)code);
                    Console.WriteLine($"Displaying Employee from {code.ToString()}");
                    foreach(var employeeData in departmentEmployees) 
                    {
                        Console.WriteLine($"\nEmployee Name : {employeeData.employeeName} | Employee Designation : {employeeData.employeeDesignation}" +
                            $" | Employee Department : {employeeData.employeeDepartment}" +
                            $" | Employee Salary : {employeeData.employeeSalary}");
                    }
                }
            }
        } 

        public static void InsertRecords(Department department,Employee employee)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                { 
                    department.AddEmployee(employee);
                    session.Save(department);
                    transaction.Commit();
                    Console.WriteLine("record entered successfully");

                }
                Console.ReadKey();
            }
        }

      
    }
}
