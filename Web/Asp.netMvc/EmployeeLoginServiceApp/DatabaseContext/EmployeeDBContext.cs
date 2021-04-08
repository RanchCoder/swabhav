using EmployeeLoginServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeLoginServiceApp.DatabaseContext
{
    public class EmployeeDBContext : DbContext 
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserCredential> UserCrendtials { get; set; }

    }
}