using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TodoListMVC.Models
{
    public class TodoList
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Registration Registration { get; set; }
        public List<SubTodoList> SubTodoLists { get; set; } = new List<SubTodoList>();
    }
}