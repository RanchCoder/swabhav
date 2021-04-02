using EmployeeCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCrudApp.ViewModels
{
    public class EmployeeVM
    {
        public List<Employee> Employees { get; set; }
    }
}