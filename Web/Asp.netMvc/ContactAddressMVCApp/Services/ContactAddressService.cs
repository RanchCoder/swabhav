using ContactAddressMVCApp.DBContext;
using ContactAddressMVCApp.Models;
using ContactAddressMVCApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAddressMVCApp.Services
{
    public class ContactAddressService
    {
        private readonly  ContactAddressDBContext _contactAddressDB;
        public ContactAddressService(ContactAddressDBContext contactAddressDB)
        {
            this._contactAddressDB = contactAddressDB;
            ContactRepository = new ContactRepository(_contactAddressDB);
            AddressRepository = new AddressRepository(_contactAddressDB);
        }

        public IContactRepository ContactRepository { get;private set; }

        public IAddressRepository AddressRepository { get; private set; }

        public Contact GetContactById(int id)
        {
            return ContactRepository.GetContactById(id);
        }
        public List<Contact> GetContacts()
        {
            return ContactRepository.GetContacts();
        }
        public List<Contact> SearchContacts(string name)
        {
            return ContactRepository.SearchContacts(name);
        }
        public void AddContact(Contact c)
        {
            ContactRepository.AddContact(c);
        }
        public void EditContact(int choice, int id, string Modification)
        {
            ContactRepository.EditContact(choice, id, Modification);
        }
        public bool DeleteContact(int id)
        {
            return ContactRepository.DeleteContact(id);
        }


        public List<Address> GetAddress(Contact c)
        {
            return AddressRepository.GetAddress(c);
        }

        public Address GetAddressById(int id)
        {
            return AddressRepository.GetAddressById(id);
        }
        public List<Address> SearchAddress(string name)
        {
            return AddressRepository.SearchAddress(name);
        }
        public void AddAddress(Contact c, Address address)
        {
            AddressRepository.AddAddress(c, address);
        }
        public bool EditAddress(int idOfContact, int idOfAddress, string Modification)
        {
            return AddressRepository.EditAddress(idOfContact, idOfAddress, Modification);
        }
        public void DeleteAddress(int idOfAddress)
        {
            AddressRepository.DeleteAddress(idOfAddress);
        }

        public void DeleteAllAddress(Contact c)
        {
            AddressRepository.DeleteAllAddress(c);
        }

        public bool Intialize()
        {
            try
            {
                Contact contact1 = new Contact() { FirstName = "Vishal", LastName = "Singh", PhoneNo = 09838349 };
                Address address1 = new Address() { Location = "Mumbai" };
                contact1.Addresses.Add(address1);
                address1.Contact = contact1;

                ContactRepository.AddContact(contact1);
                AddressRepository.AddAddress(contact1, address1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


    }
}