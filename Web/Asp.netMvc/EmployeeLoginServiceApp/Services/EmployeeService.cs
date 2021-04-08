using EmployeeLoginServiceApp.DatabaseContext;
using EmployeeLoginServiceApp.Models;
using EmployeeLoginServiceApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLoginServiceApp.Services
{
    public class EmployeeService
    {
        private EmployeeRepository employeeRepository;
        public EmployeeService()
        {
            this.employeeRepository = new EmployeeRepository(new EmployeeDBContext());
        }

        public void AddEmployee(Employee employee)
        {
            this.employeeRepository.AddEmployee(employee);
        }

        public bool IsAuthenticUser(string username, string password)
        {
            return this.employeeRepository.IsAuthenticUser(username,password);
        }

        public Employee GetEmployeeData(string username, string password)
        {
            return this.employeeRepository.GetEmployeeData(username,password);
        }

        public List<Employee> GetEmployees()
        {
            return this.employeeRepository.GetEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return this.employeeRepository.GetEmployeeById(id);
        }
        public bool InitializeTables()
        {
            return this.employeeRepository.InitializeTables();
        }


    }
}