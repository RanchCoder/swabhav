using FirstWebBasedDatabaseApp.Models;
using FirstWebBasedDatabaseApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebBasedDatabaseApp.Repository
{
    public class ContactRepository : IContactRepository
    {
        private const int FIRSTNAME = 1;
        private const int LASTNAME = 2;
        private const int PHONENO = 3;

        public ContactDBContext contactDB;
        public ContactService contactService;
        public ContactRepository(ContactDBContext contactDB,ContactService contactService)
        {
            this.contactDB = contactDB;
            this.contactService = contactService;
        }

        string IContactRepository.AddContacts()
        {
            try
            {
                foreach (var contact in contactService.Contacts)
                {
                    contactDB.Contacts.Add(contact);
                    contactDB.SaveChanges();
                    
                }
                return "Success";
            }
            catch(Exception ex)
            {
                return "Failure";
            }
            
        } 
        void IContactRepository.AddContact(Contact c)
        {

            contactDB.Contacts.Add(c);
            contactDB.SaveChanges();
        }

        void IContactRepository.DeleteContact(int id)
        {
            var contactToDelete = contactDB.Contacts.Single(x => x.Id == id);
            contactDB.Contacts.Remove(contactToDelete);
            contactDB.SaveChanges();
        }

        void IContactRepository.EditContact(int choice, int id, string Modification)
        {
            foreach (Contact c in contactDB.Contacts)
            {
                if (c.Id == id)
                {
                    if (choice == FIRSTNAME)
                    {
                        c.FirstName = Modification;
                    }
                    if (choice == LASTNAME)
                    {
                        c.LastName = Modification;
                    }
                    if (choice == PHONENO)
                    {
                        c.PhoneNo = long.Parse(Modification);
                    }
                }
            }
            contactDB.SaveChanges();
        }

        List<Contact> IContactRepository.GetContacts()
        {
            return this.contactDB.Contacts.ToList();

        }

        List<Contact> IContactRepository.SearchContacts(string name)
        {
            List<Contact> searchedContacts = new List<Contact>();
            foreach (Contact c in contactDB.Contacts)
            {
                if (c.FirstName.Contains(name) || c.LastName.Contains(name))
                {
                    searchedContacts.Add(c);
                }
            }
            return searchedContacts;
        }
    }

}