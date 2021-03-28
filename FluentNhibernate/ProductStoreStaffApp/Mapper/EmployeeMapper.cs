using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProductStoreStaffApp.Entity;

namespace ProductStoreStaffApp.Mapper
{
    public class EmployeeMapper : ClassMap<Employee>
    {
        public EmployeeMapper()
        {
            Id(x => x.Id);
            Map(x=>x.FirstName);
            Map(x=>x.LastName);
            References(x => x.Store);
            Table("tbl_employee");
        }
    }
}
