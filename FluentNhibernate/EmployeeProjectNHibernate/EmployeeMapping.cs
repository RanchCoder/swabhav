using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;


namespace EmployeeProjectNHibernate
{
    class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Id(x => x.Id);

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            
            Map(x => x.Designation)
                .Length(50)
                .Not.Nullable();
            
            Map(x => x.Salary)
                .Length(10)
                .Not.Nullable();

            
            References(x => x.Department)
                .Column("Department");
        }
    }
}
