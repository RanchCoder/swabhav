using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TodoListMVC.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public  string UserName { get; set; }



        [Required]
        public string Password { get; set; }

        public List<TodoList> UserTodoLists { get; set; } = new List<TodoList>();
    }
}