using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryModelEntityFramework.Model;

namespace RepositoryModelEntityFramework.DataBaseContext
{
    class ContactDbContext : DbContext
    {
      public  DbSet<Contact> Contacts { get; set; }
    }
}
