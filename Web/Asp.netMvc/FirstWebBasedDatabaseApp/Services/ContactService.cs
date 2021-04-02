using FirstWebBasedDatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebBasedDatabaseApp.Services
{
    public class ContactService
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>()
        {
            new Contact(){FirstName="vishal",LastName="singh",Address="kurla(west)",PhoneNo=9852733},
             new Contact(){FirstName="prem",LastName="singh",Address="kurla(west)",PhoneNo=448733},
              new Contact(){FirstName="Danish",LastName="singh",Address="kurla(west)",PhoneNo=595233},
        };

        public List<Contact> GetContact()
        {
            return this.Contacts;
        }
    }
}