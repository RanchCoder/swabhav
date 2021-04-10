using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstWebApiApp.Models;

namespace FirstWebApiApp.Services
{
    public class EmployeeService
    {
        private static EmployeeService _employeeService;
        private EmployeeService() { }

        public  List<Employee> employeeList = new List<Employee>();
        public static EmployeeService GetEmployeeService()
        {
            if(_employeeService == null)
            {
                _employeeService = new EmployeeService();
            }
           
            return _employeeService;
        }

        public void InitializeEmployeeList()
        {
            if(_employeeService.employeeList.Count() == 0)
            {
                _employeeService.employeeList.Add(new Employee() { Id = 1, Name = "Vishal", DepartmentName = "IT", Designation = "Manager", Salary = 14000 });
            }
        }
        public List<Employee> GetEmployeeList()
        {
            return _employeeService.employeeList;
        }
    }
}