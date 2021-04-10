using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeRoutingApi.DTO;
using EmployeeRoutingApi.Models;

namespace EmployeeRoutingApi.Service
{
    public class EmployeeService
    {
        private static EmployeeService employeeService;
        public const bool FAILED_OPERATION = false , SUCCESS_OPERATION = true;

        public List<Employee> Employees { get; set; } = new List<Employee>();
        private EmployeeService() { }
        public static EmployeeService GetEmployeeService()
        {
            if(employeeService == null)
            {
                employeeService = new EmployeeService();
            }
            return employeeService;
        }

        public void IntializeList()
        {
            if(Employees.Count() == 0)
            {
                Employees.Add(new Employee() { Id = 1, Name = "Vishal", Designation = "Manager", Department = "IT", Salary = 15000 });

            }
        }
        
        public bool AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {

                Employees.Add(new Employee() {

                    Id = employeeDTO.Id,
                    Name = employeeDTO.Name,
                    Department = employeeDTO.Department,
                    Designation = employeeDTO.Designation,
                    Salary = employeeDTO.Salary,

                });
                
                    
                   
                
                return SUCCESS_OPERATION;
            }
            catch(Exception ex)
            {
                return FAILED_OPERATION;
            }
        }

        public bool UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                foreach (var employee in employeeService.Employees.Where(emp => emp.Id == employeeDTO.Id))
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

        public bool DeleteEmployee(DeleteEmployeeDTO deleteEmployeeDTO)
        {
            var employeeToDelete = employeeService.Employees.Where(emp => emp.Id == deleteEmployeeDTO.Id).FirstOrDefault();
            return employeeService.Employees.Remove(employeeToDelete);

        }

    }
}