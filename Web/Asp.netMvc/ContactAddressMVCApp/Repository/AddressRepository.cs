using ContactAddressMVCApp.DBContext;
using ContactAddressMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ContactAddressMVCApp.Repository
{
    public class AddressRepository : IAddressRepository
    {
        public const bool FAILED_OPERATION = false , PASSED_OPERATION = true;
        public readonly ContactAddressDBContext contactAddressDB;

        public AddressRepository(ContactAddressDBContext contactAddressDB)
        {
            this.contactAddressDB = contactAddressDB;
        }
        public void AddAddress(Contact contact, Address address)
        {
            contact.Addresses.Add(address);
            address.Contact = contact;
            contactAddressDB.SaveChanges();
        }

        public void DeleteAddress(int idOfAddress)
        {
            var addressToDelete = contactAddressDB.Addresses.Single(x => x.Id == idOfAddress);
            contactAddressDB.Addresses.Remove(addressToDelete);
            contactAddressDB.SaveChanges();
        }

        public void DeleteAllAddress(Contact contact)
        {
            var allAddressesOfContact = contactAddressDB.Addresses.Where(x => x.Contact.Id == contact.Id);
            foreach (var address in allAddressesOfContact)
            {
                contactAddressDB.Addresses.Remove(address);
            }
            contactAddressDB.SaveChanges();
        }

        public bool EditAddress(int idOfContact, int idOfAddress, string Modification)
        {
            try
            {
                foreach (Address address in contactAddressDB.Addresses.Where(x=>x.Id == idOfAddress))
                {
                    
                        address.Location = Modification;
                    
                }
                contactAddressDB.SaveChanges();
                return PASSED_OPERATION;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return FAILED_OPERATION;
            }
            
        }

        public List<Address> GetAddress(Contact c)
        {
            return contactAddressDB.Addresses.Where(x => x.Contact.Id == c.Id).ToList();
        }

        public Address GetAddressById(int id)
        {
            return contactAddressDB.Addresses.Where(address=>address.Id == id).FirstOrDefault();
        }
        public List<Address> SearchAddress(string name)
        {
            List<Address> searchedAddresses = new List<Address>();
            foreach (Address address in contactAddressDB.Addresses)
            {
                if (address.Location.Contains(name))
                {
                    searchedAddresses.Add(address);
                }
            }
            return searchedAddresses;
        }

        public bool IntializeAddress()
        {
            try
            {
                contactAddressDB.SaveChanges();
                return PASSED_OPERATION;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return FAILED_OPERATION;
            }
        }

        
    }
}