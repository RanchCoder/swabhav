using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAddressMVCApp.Models
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual long PhoneNo { get; set; }
        public virtual IList<Address> Addresses { get; set; } = new List<Address>();
    }
}