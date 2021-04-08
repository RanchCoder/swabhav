using EmployeeLoginServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLoginServiceApp.Repository
{
    interface IEmployeeRepository
    {
         bool IsAuthenticUser(string username,string password);
        void AddEmployee(Employee employee);

        List<Employee> GetEmployees();
        Employee GetEmployeeData(string username, string password);

        Employee GetEmployeeById(int id);

         bool InitializeTables();
    }
}
