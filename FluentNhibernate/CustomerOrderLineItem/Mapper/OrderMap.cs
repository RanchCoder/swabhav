using CustomerOrderLineItem.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderLineItem.Mapper
{
   public class OrderMap : ClassMap<Order>
    {
       public OrderMap()
        {
            Id(x => x.Id);
            References(x => x.Customer);
            HasMany(x => x.LineItems)     
                .Inverse()
                .Cascade.All();
            Table("tbl_order");
        }
    }
}
