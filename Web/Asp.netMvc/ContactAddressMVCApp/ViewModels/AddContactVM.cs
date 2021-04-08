using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactAddressMVCApp.ViewModels
{
    public class AddContactVM
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual long PhoneNo { get; set; }
    }
}