using FirstWebBasedDatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstWebBasedDatabaseApp.Repository
{
    public class ContactDBContext : DbContext
    {
       public DbSet<Contact> Contacts { get; set; }
    }
}