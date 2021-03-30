using ContactAddressHibernateApp.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressHibernateApp.Mapper
{
    class AddressMapper : ClassMap<Address>
    {
        public AddressMapper()
        {
            Id(x => x.Id);
            Map(x => x.Location).Length(1000);
            References(x => x.Contact);
            Table("tbl_addresses");

        }
    }
}
