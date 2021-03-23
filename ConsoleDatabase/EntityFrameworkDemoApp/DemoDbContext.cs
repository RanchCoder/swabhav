using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemoApp.Model;

namespace EntityFrameworkDemoApp
{
    class DemoDbContext : DbContext
    {
        
        public DbSet<Employee> Employees { get; set; }
    }
}
