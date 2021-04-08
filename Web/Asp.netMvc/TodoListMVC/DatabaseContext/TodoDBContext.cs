using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoListMVC.Models;
using System.Data.Entity;
namespace TodoListMVC.DatabaseContext
{
    public class TodoDBContext : DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<SubTodoList> SubTodoLists { get; set; }

        public DbSet<Registration> Registrations { get; set; }

    }
}