using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRoutingApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
}