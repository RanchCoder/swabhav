using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactWebApi.ViewModels
{
    public class ContactVM
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual long PhoneNo { get; set; }
        public virtual string Address { get; set; }
    }
}