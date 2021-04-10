using EmployeeWithNinjectApp.DTO;
using EmployeeWithNinjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWithNinjectApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static EmployeeService employeeService;
        public const bool FAILED_OPERATION = false, SUCCESS_OPERATION = true;

        public static List<Employee> Employees { get; set; } = new List<Employee>();
        public EmployeeService() { }
        public static IEmployeeService GetEmployeeService()
        {
            if (employeeService == null)
            {
                employeeService = new EmployeeService();
            }
            return employeeService;
        }

        public void InitializeList()
        {
            if (Employees.Count() == 0)
            {
                Employees.Add(new Employee() { Id = 1, Name = "Vishal", Designation = "Manager", Department = "IT", Salary = 15000 });

            }
        }

        public bool AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {

                Employees.Add(new Employee()
                {

                    Id = employeeDTO.Id,
                    Name = employeeDTO.Name,
                    Department = employeeDTO.Department,
                    Designation = employeeDTO.Designation,
                    Salary = employeeDTO.Salary,

                });

                return SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                return FAILED_OPERATION;
            }

        }

        public bool DeleteEmployee(int id)
        {
            
                var employeeToDelete = Employees.Where(emp => emp.Id == id).FirstOrDefault();
                return Employees.Remove(employeeToDelete);         
           
        }

        public List<Employee> GetEmployees()
        {
           return Employees;
        }

        public bool UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                foreach (var employee in Employees.Where(emp => emp.Id == employeeDTO.Id))
                {
                    employee.Id = employeeDTO.Id;
                    employee.Name = employeeDTO.Name;
                    employee.Department = employeeDTO.Department;
                    employee.Designation = employeeDTO.Designation;
                    employee.Salary = employeeDTO.Salary;

                }
                return SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                return FAILED_OPERATION;
            }
        }
    }
}