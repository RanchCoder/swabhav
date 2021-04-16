using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoListMVC.ViewModels
{
    public class RegistrationVM
    {
        [Key]
        public int Id { get; set; }

       
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password",ErrorMessage ="Password and compare password must match")]
        public string ConfirmPassword { get; set; }


    }
}