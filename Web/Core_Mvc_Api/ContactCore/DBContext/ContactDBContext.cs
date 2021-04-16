using ContactCore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCore.DBContext
{
    public class ContactDBContext : DbContext 
    {
        
        public ContactDBContext() : base()
        {
            // the terrible hack
            var ensureDLLIsCopied =
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
