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

        [Required(ErrorMessage ="Username is required")]
        public  string UserName { get; set; }



        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public List<TodoList> UserTodoLists { get; set; } = new List<TodoList>();
    }
}