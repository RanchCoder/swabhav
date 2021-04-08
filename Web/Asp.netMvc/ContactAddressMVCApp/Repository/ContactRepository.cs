using ContactAddressMVCApp.DBContext;
using ContactAddressMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAddressMVCApp.Repository
{
    public class ContactRepository : IContactRepository
    {

        public const bool FAILED_OPERATION = false, PASSED_OPERATION = true;
        private const int FIRSTNAME = 1;
        private const int LASTNAME = 2;
        private const int PHONENO = 3;

        public readonly ContactAddressDBContext contactAddressDB;
        public ContactRepository(ContactAddressDBContext contactAddressDB)
        {
            this.contactAddressDB = contactAddressDB;
        }

        

        public void AddContact(Contact c)
        {
            contactAddressDB.Contacts.Add(c);
            contactAddressDB.SaveChanges();
        }

        

        public bool DeleteContact(int id)
        {
            try
            {
                var contactToDelete = contactAddressDB.Contacts.Single(x => x.Id == id);
                var addressesToDelete = contactAddressDB.Addresses.Where(x => x.Contact.Id == id).ToList();
                foreach (var address in addressesToDelete)
                {
                    contactAddressDB.Addresses.Remove(address);
                }
                contactAddressDB.Contacts.Remove(contactToDelete);
                contactAddressDB.SaveChanges();
                return PASSED_OPERATION;
            }
            catch (Exception ex)
            {
                return FAILED_OPERATION;
            }
            
        }

        

        public void EditContact(int choice, int id, string Modification)
        {
            foreach (Contact c in contactAddressDB.Contacts)
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
            contactAddressDB.SaveChanges();
        }

        

        public Contact GetContactById(int id)
        {
            var contactList = this.contactAddressDB.Contacts
                 .Where(x => x.Id == id).SingleOrDefault();
            return contactList;
        }

        public List<Contact> GetContacts()
        {
            return this.contactAddressDB.Contacts.ToList();
        }

        
        public List<Contact> SearchContacts(string contatName)
        {
            List<Contact> searchedContacts = new List<Contact>();
            foreach (Contact c in contactAddressDB.Contacts)
            {
                if (c.FirstName.Contains(contatName) || c.LastName.Contains(contatName))
                {
                    searchedContacts.Add(c);
                }
            }
            return searchedContacts;
        }

        public bool IntializeContact()
        {
            try
            {
                
                contactAddressDB.SaveChanges();
                return PASSED_OPERATION;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return FAILED_OPERATION;
            }
        }

        
    }
}