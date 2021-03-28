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
            HasManyToMany(x => x.LineItems)               
                .Cascade.All();
            Table("tbl_order");
        }
    }
}
