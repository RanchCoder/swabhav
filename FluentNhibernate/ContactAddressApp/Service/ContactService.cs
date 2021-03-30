using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAddressApp.Repository;
using ContactAddressApp.Model;

namespace ContactAddressApp.Service
{
    class ContactService
    {
        private IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Contact GetContactById(int id)
        {
            return contactRepository.GetContactById(id);
        }
        public List<Contact> GetContacts()
        {
            return contactRepository.GetContacts();
        }
        public List<Contact> SearchContacts(string name)
        {
            return contactRepository.SearchContacts(name);
        }
        public void AddContact(Contact c)
        {
            contactRepository.AddContact(c);
        }
        public void EditContact(int choice, int id, string Modification)
        {
            contactRepository.EditContact(choice, id, Modification);
        }
        public void DeleteContact(int id)
        {
            contactRepository.DeleteContact(id);
        }


        public List<Address> GetAddress(Contact c)
        {
            return contactRepository.GetAddress(c);
        }
        public List<Address> SearchAddress(string name)
        {
            return contactRepository.SearchAddress(name);
        }
        public void AddAddress(Contact c, Address address)
        {
            contactRepository.AddAddress(c, address);
        }
        public void EditAddress(int idOfContact, int idOfAddress, string Modification)
        {
            contactRepository.EditAddress(idOfContact, idOfAddress, Modification);
        }
        public void DeleteAddress(int idOfAddress)
        {
            contactRepository.DeleteAddress(idOfAddress);
        }

        public void DeleteAllAddress(Contact c)
        {
            contactRepository.DeleteAllAddress(c);
        }

      

    }
}
