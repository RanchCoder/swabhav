﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressHibernateApp.Model
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int PhoneNo { get; set; }
        public virtual IList<Address> Addresses { get; set; } = new List<Address>();

        public virtual void AddContactAddress(Address address)
        {
            address.Contact = this;
            Addresses.Add(address);

        }
    }
}
