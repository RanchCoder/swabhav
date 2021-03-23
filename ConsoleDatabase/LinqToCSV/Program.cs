using System;
using System.Collections.Generic;
using System.IO;
using LinqToCSV.Model;
using System.Linq;

namespace LinqToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string employeeCSVPath = @"C:\swabhav\ConsoleDatabase\Employee.csv";
            string departmentCSVPath = @"C:\swabhav\ConsoleDatabase\Department.csv";

            var employees = ProcessEmployeeCSV(employeeCSVPath);

            var sumOfSalaries = employees.Sum(x => x.EmployeeSalary);
           // Console.WriteLine($"Sum of salaries of all employees : {sumOfSalaries}");

            

            var departments = ProcessDepartmentCSV(departmentCSVPath);
            // PrintEmployeeDetails(employees);

            var joinResultOfEmpDept = employees.Join(departments,
                employee => employee.EmpDeptNo,
                department => department.DeptNo,
                (employee, department) => new
                {
                    employeeName = employee.EmployeeName,
                    employeeSalary = employee.EmployeeSalary,
                    employeeDesignation = employee.Employee_designation,
                    departmentName = department.DeptName,
                    departmentLocation = department.Location

                });

            var getEmployeeAlongWithDepartment = employees.Join(departments, employee => employee.EmpDeptNo, department => department.DeptNo, (employee, department) => new
            {
                employeeName = employee.EmployeeName,
                employeeDesignation = employee.Employee_designation,
                departmentNumber = employee.EmpDeptNo,
            });

            foreach(var record in getEmployeeAlongWithDepartment)
            {
                Console.WriteLine($"Employee Name : {record.employeeName} | Employee Designation : {record.employeeDesignation} | Department No : {record.departmentNumber}");
            }

            //foreach(var record in joinResultOfEmpDept)
            //{
            //    Console.WriteLine($"Employee Name : {record.employeeName} | Employee Salary : {record.employeeSalary} | Employee Designation : {record.employeeDesignation} |" +
            //        $"Department Name : {record.departmentName} | Department Location : {record.departmentLocation} | ");
            //}

           // PrintDepartmentDetails(departments);
            Console.ReadLine();
        }

        private static void PrintEmployeeDetails(List<Employee> employees)
        {

            Console.WriteLine($"Employee ID | EMPLOYEE NAME | EMPLOYEE SALARY | EMPLOYEE DESIGNATION | EMPLOYEE DEPARTMENT");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.EmpDeptNo}     | {employee.EmployeeName}  | {employee.EmployeeSalary}  | {employee.Employee_designation}  | {employee.EmpDeptNo}");
            }
        }

        private static void PrintDepartmentDetails(List<Department> departments)
        {

            Console.WriteLine($"\nDepartment No | Department Name | Department Location");
            foreach (Department department in departments)
            {
                Console.WriteLine($"{department.DeptNo}   | {department.DeptName}  | {department.Location}");
            }
        }

        private static List<Employee> ProcessEmployeeCSV(string CSVPath)
        {
           return File.ReadAllLines(CSVPath)
               .Skip(1)
               .Where(row => row.Length > 0)
               .Select(ParseEmployeeRow).ToList();
        }

        private static List<Department> ProcessDepartmentCSV(string CSVPath)
        {
            return File.ReadAllLines(CSVPath)
            .Skip(1)
            .Where(row => row.Length > 0)
            .Select(ParseDepartmentRow).ToList();


        }

        private static Employee ParseEmployeeRow(string rowData)
        {
            var column = rowData.Split(',');
            return new Employee()
            {
                EmployeeId = Int32.Parse(column[0]),
                EmployeeName = column[1],
                EmployeeSalary = Int32.Parse(column[3]),
                Employee_designation = column[4],
                EmpDeptNo = Int32.Parse(column[5]),

            };
        }
        private static Department ParseDepartmentRow(string rowData)
        {
            var column = rowData.Split(',');
            return new Department()
            {
                DeptNo = Int32.Parse(column[0]),
                DeptName = column[1],
                Location = column[2]
            };
        }
    }
}
