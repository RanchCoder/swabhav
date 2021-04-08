using EmployeeCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCrudApp.Service
{
    public class EmployeeService
    {
        public static List<Employee> EmployeeList;
        public EmployeeService()
        {
            EmployeeList = new List<Employee>();

        }

        public int AddEmployee(Employee employee)
        {
            try
            {
                EmployeeList.Add(employee);
                return EmployeeList.Count;

            }catch(Exception ex)
            {
                return -0;
            }
        }

        public List<Employee> GetEmployeeData()
        {
            return EmployeeList;
        }

        public  Employee GetEmployeeById(int id)
        {
            return EmployeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public  string EditEmployeeData(Employee employee)
        {
            try
            {
                foreach (var emp in EmployeeList.Where(x => x.Id == employee.Id))
                {
                    emp.Id = employee.Id;
                    emp.Name = employee.Name;
                    emp.Department = employee.Department;
                    emp.Designation = employee.Designation;
                    emp.Salary = employee.Salary;
                }
                return "SUCCESS";
            }catch(Exception ex)
            {
                return "FAILURE";
            }
            
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                EmployeeList.Remove(EmployeeList.Where(emp => emp.Id == id).Single());
                return "SUCCESS";
            }catch(Exception ex)
            {
                return "FAILURE";
            }
        }
    }
}