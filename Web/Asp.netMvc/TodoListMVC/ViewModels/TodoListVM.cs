using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TodoListMVC.Models;

namespace TodoListMVC.ViewModels
{
    public class TodoListVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public List<SubTodoList> SubTodoLists { get; set; } = new List<SubTodoList>();
    }
}