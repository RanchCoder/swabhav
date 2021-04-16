using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactMVC.ViewModels
{
    public class ContactViewModel
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public virtual long PhoneNo { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public virtual string Address { get; set; }
    }
}