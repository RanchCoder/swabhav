using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProductStoreStaffApp.Entity;

namespace ProductStoreStaffApp.Mapper
{
    public class ProductMapper : ClassMap<Product>
    {
        public ProductMapper()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x=>x.Price);
            HasManyToMany(x => x.StoreStockedIn)
                .Inverse()
                .Cascade.All()
                .Table("tbl_StoreProduct");

        }
    }
}
