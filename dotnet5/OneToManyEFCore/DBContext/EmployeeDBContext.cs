using Microsoft.EntityFrameworkCore;
using OneToManyEFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneToManyEFCore.DBContext
{
    class EmployeeDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Database=coreStudent;User Id=sa;Password=root");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Department>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
    }
 }

