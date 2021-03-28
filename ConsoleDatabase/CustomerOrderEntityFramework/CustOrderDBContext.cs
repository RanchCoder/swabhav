using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerOrderEntityFramework.Model;
namespace CustomerOrderEntityFramework
{
    class CustOrderDBContext : DbContext 
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
