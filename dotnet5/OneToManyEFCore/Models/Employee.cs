using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneToManyEFCore.Models
{
    class Employee
    {
        [Key]
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string Designtion { get; set; }
        public float Salary { get; set; }

        [ForeignKey("dept_id")]
        public Department Department { get; set; }
        

    }
}
