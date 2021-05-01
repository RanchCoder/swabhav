using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstCoreWebApplication.Models;

namespace FirstCoreWebApplication.Data
{
    public class FirstCoreWebApplicationContext : DbContext
    {
        public FirstCoreWebApplicationContext (DbContextOptions<FirstCoreWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FirstCoreWebApplication.Models.Student> Student { get; set; }
    }
}
