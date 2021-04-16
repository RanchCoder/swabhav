using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWebApiApp.Models
{
    public class Employee
    {
        [Required]
        public  int Id { get; set; }
        public string Name { get; set; }
        public string  DepartmentName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
}