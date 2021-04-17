using EFCoreConsoleApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.DBContext
{
    class CollegeDBContext : DbContext 
    {

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Database=coreStudent;User Id=sa;Password=root");
        }


        public DbSet<Student> Students { get; set; }
    }

}
