using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebBasedDatabaseApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNo { get; set; }

        public string Address { get; set; }

    }
}