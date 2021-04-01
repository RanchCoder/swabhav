using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidateAndAuthenticateApp.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter Password")]
        public string Password { get; set; }
    }
}