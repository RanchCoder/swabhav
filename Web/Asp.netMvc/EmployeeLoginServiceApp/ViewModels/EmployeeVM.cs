using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLoginServiceApp.ViewModels
{
    public class EmployeeVM
    {
        [Required]
        public int Id { get; set; }

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


    }
}