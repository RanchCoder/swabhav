using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoListMVC.Models
{
    public class User
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

    }
}