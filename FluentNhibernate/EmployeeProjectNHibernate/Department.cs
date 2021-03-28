using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjectNHibernate
{
    public class Department
    {
        public virtual int Id { get; set; }

        public virtual string Location { get; set; }

        public virtual string DeptName { get; set; }

        public virtual IList<Employee> Employees { get; set; } = new List<Employee>();

        public virtual void AddEmployee(Employee employee)
        {
            employee.Department = this;
            Employees.Add(employee);

        }
    }
}
