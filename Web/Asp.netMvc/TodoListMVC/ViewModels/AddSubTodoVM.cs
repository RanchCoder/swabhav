using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoListMVC.ViewModels
{
    public class AddSubTodoVM
    {
        public int TodoListId { get; set; }

        [Required]
        public string SubTodoName { get; set; }

    }
}