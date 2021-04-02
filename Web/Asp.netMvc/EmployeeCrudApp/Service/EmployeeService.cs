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
    }
}