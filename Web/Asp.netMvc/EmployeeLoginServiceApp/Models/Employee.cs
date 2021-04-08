using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeLoginServiceApp.Models
{
    public class Employee
    {
        [Required]
        [Key]
        public  int Id{ get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string Designation { get; set; }

        [Required]
        public virtual string Department { get; set; }

        [Required]
        public virtual int Salary { get; set; }


        public virtual UserCredential UserCredential { get; set; }
    }
}