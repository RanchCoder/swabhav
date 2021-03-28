using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjectNHibernate
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Salary { get; set; }
        public virtual String Designation { get; set; }
        public virtual Department Department { get; set; }
    }
}
