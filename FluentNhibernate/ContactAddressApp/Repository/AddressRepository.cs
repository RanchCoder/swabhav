using ContactAddressApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAddressApp.DatabaseContext;

namespace ContactAddressApp.Repository
{
    class AddressRepository : IAddressRepository
    {
        public RepositoryModelDbContext addressDB;

        public AddressRepository(RepositoryModelDbContext addressDB)
        {
            this.addressDB = addressDB;
        }
        void IAddressRepository.AddAddress(Contact contact, Address address)
        {
            contact.Address.Add(address);
            address.Contact = contact;
            addressDB.SaveChanges();
        }

        void IAddressRepository.DeleteAddress(int idOfAddress)
        {
            var addressToDelete = addressDB.Address.Single(x => x.Id == idOfAddress);
            addressDB.Address.Remove(addressToDelete);
            addressDB.SaveChanges();
        }

        void IAddressRepository.DeleteAllAddress(Contact contact)
        {
            var allAddressesOfContact = addressDB.Address.Where(x => x.Contact.Id == contact.Id);
            foreach(var address in allAddressesOfContact)
            {
                addressDB.Address.Remove(address);
            }
            addressDB.SaveChanges();
        }

        void IAddressRepository.EditAddress(int idOfContact,int idOfAddress,string Modification)
        {
            var addressToBeChanged = addressDB.Address.Where(x=>x.Contact.Id == idOfContact);
            foreach (Address address in addressDB.Address)
            {
                if (address.Contact.Id == idOfContact && address.Id == idOfAddress)
                {
                    address.Location = Modification;
                }
            }
            addressDB.SaveChanges();
        }

        List<Address> IAddressRepository.GetAddress(Contact c)
        {
            return addressDB.Address.Where(x => x.Contact.Id == c.Id).ToList();
        }

        List<Address> IAddressRepository.SearchAddress(string name)
        {
            List<Address> searchedAddresses = new List<Address>();
            foreach (Address address in addressDB.Address)
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
