using ContactAddressApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressApp.DatabaseContext
{
   public class RepositoryModelDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
