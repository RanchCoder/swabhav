using ContactAddressApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressApp.Repository
{
    interface IContactRepository
    {
        List<Contact> GetContacts();
        List<Contact> SearchContacts(string name);
        void AddContact(Contact c);
        void EditContact(int choice, int id, string Modification);
        void DeleteContact(int id);
        Contact GetContactById(int id);
        List<Address> GetAddress(Contact c);
        List<Address> SearchAddress(string name);
        void AddAddress(Contact contact, Address address);
        void EditAddress(int idOfContact, int idOfAddress, string Modification);
        void DeleteAddress(int idOfContact);
        void DeleteAllAddress(Contact contact);
       
    }
}
