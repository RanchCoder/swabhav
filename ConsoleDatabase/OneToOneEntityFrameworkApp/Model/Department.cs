using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OneToOneEntityFrameworkApp.Model
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Employee> DeptEmployees { get; }

        public Department()
        {
            DeptEmployees = new List<Employee>();
        }
    }
}
