using EmployeeWithNinjectApp.DTO;
using EmployeeWithNinjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWithNinjectApp.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        bool AddEmployee(EmployeeDTO employeeDTO);
        bool UpdateEmployee(EmployeeDTO employeeDTO);
        bool DeleteEmployee(int id);
        void InitializeList();
    }
}
