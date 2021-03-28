using CustomerOrderLineItem.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderLineItem.Mapper
{
    class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Price);
            HasMany(x => x.lineItems)
                .Inverse()
                .Cascade.All();
            Table("tbl_product");
        }
    }
}
