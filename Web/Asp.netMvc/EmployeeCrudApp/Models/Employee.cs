using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCrudApp.Models
{
    public class Employee
    {
        public  int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Department { get; set; }
    }
}