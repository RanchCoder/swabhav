using CustomerOrderLineItem.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderLineItem.Mapper
{
    public class LineItemMap : ClassMap<LineItem>
    {
        public LineItemMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            References(x => x.ProductType);

            References(x => x.Order)                
                .Cascade.All();
            Table("tbl_lineItem");
        }
    }
}
