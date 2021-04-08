using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TodoListMVC.Models
{
    public class SubTodoList
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string SubTodoName { get; set; }
        
        [Required]
        public virtual DateTime SubTodoDate { get; set; }

        [Required]
        public virtual bool SubTodoStatus { get; set; }
        
        [Required]
        public virtual TodoList TodoList { get; set; }

    }
}