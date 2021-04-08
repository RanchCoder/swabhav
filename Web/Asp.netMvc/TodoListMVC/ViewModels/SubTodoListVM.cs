using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TodoListMVC.Models;

namespace TodoListMVC.ViewModels
{
    public class SubTodoListVM
    {
        
        public virtual int Id { get; set; }

      
        public virtual string SubTodoName { get; set; }

       
        public virtual DateTime SubTodoDate { get; set; }

      
        public virtual bool SubTodoStatus { get; set; }

        
        
    }
}