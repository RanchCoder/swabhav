using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAddressEntityFramework.Model
{
    [Table("Address")]

    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Detail { get; set; }      
        public virtual Employee Emp { get; set; }
    }
}
