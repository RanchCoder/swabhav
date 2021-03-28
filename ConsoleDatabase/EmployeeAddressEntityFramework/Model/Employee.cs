using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAddressEntityFramework.Model
{

    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public virtual List<Address> EmpAddress{ get; set; }

        public Employee()
        {
            EmpAddress = new List<Address>();
        }
    }

}
