using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace EmployeeProjectNHibernate
{
    class DepartmentMapping : ClassMap<Department>
    {
        public DepartmentMapping()
        {
            Id(x => x.Id);

            Map(x => x.DeptName)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Location)
                .Length(50)
                .Not.Nullable();

            HasMany(x => x.Employees)
                .Inverse()
                .Cascade.All()
                .KeyColumn("Department");
        }
    }
}
