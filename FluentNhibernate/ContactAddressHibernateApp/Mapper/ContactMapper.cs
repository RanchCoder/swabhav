using ContactAddressHibernateApp.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressHibernateApp.Mapper
{
    class ContactMapper : ClassMap<Contact>
    {
        public ContactMapper()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.PhoneNo);
            HasMany(x => x.Addresses)
                .Inverse()
                .Cascade.All();
            Table("tbl_contact");
        }
    }
}
