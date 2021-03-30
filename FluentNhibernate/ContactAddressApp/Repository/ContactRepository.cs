using ContactAddressApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactAddressApp.DatabaseContext;

namespace ContactAddressApp.Repository
{
    class ContactRepository : IContactRepository 
    {

        private const int FIRSTNAME = 1;
        private const int LASTNAME = 2;
        private const int PHONENO = 3;

        public RepositoryModelDbContext contactDB;

        public ContactRepository(RepositoryModelDbContext contactDB)
        {
            this.contactDB = contactDB;
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

        Contact IContactRepository.GetContactById(int id)
        {
            var contactList = this.contactDB.Contacts
                .Where(x => x.Id == id).SingleOrDefault();
            return contactList;
            
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

        void IContactRepository.AddAddress(Contact contact, Address address)
        {
            contact.Address.Add(address);
            address.Contact = contact;
            contactDB.SaveChanges();
        }

        void IContactRepository.DeleteAddress(int idOfAddress)
        {
            var addressToDelete = contactDB.Address.Single(x => x.Id == idOfAddress);
            contactDB.Address.Remove(addressToDelete);
            contactDB.SaveChanges();
        }

        void IContactRepository.DeleteAllAddress(Contact contact)
        {
            var allAddressesOfContact = contactDB.Address.Where(x => x.Contact.Id == contact.Id);
            foreach (var address in allAddressesOfContact)
            {
                contactDB.Address.Remove(address);
            }
            contactDB.SaveChanges();
        }

        void IContactRepository.EditAddress(int idOfContact, int idOfAddress, string Modification)
        {
            var addressToBeChanged = contactDB.Address.Where(x => x.Contact.Id == idOfContact);
            foreach (Address address in contactDB.Address)
            {
                if (address.Contact.Id == idOfContact && address.Id == idOfAddress)
                {
                    address.Location = Modification;
                }
            }
            contactDB.SaveChanges();
        }

        List<Address> IContactRepository.GetAddress(Contact c)
        {
            return contactDB.Address.Where(x => x.Contact.Id == c.Id).ToList();
        }

        List<Address> IContactRepository.SearchAddress(string name)
        {
            List<Address> searchedAddresses = new List<Address>();
            foreach (Address address in contactDB.Address)
            {
                if (address.Location.Contains(name))
                {
                    searchedAddresses.Add(address);
                }
            }
            return searchedAddresses;
        }

        
        
    }
}
