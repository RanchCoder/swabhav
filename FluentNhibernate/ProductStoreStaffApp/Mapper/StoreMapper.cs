using FluentNHibernate.Mapping;
using ProductStoreStaffApp.Entity;
namespace ProductStoreStaffApp.Mapper
{
    class StoreMapper : ClassMap<Store>
    {
        public StoreMapper()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x=>x.Staff)
                .Inverse()
                .Cascade.All();
            
            HasManyToMany(x =>x.Products)
                .Cascade.All()
                .Table("tbl_StoreProduct");

        }
    }
}
