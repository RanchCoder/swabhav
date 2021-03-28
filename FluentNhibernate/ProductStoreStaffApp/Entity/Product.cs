using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductStoreStaffApp.Entity
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual IList<Store> StoreStockedIn { get; set; }
        public Product()
        {
            StoreStockedIn =new List<Store>();
        }
    }
}
