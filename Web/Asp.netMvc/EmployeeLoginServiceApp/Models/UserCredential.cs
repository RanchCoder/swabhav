using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EmployeeLoginServiceApp.Models
{
    public class UserCredential
    {
        [Key, System.ComponentModel.DataAnnotations.Schema.ForeignKey("Employee")]
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
       

        [Required]
        public virtual Employee Employee { get; set; }
    }
}