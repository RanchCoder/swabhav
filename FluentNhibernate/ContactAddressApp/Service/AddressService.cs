using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAddressApp.Repository;
using ContactAddressApp.Model;

namespace ContactAddressApp.Service
{
    class AddressService
    {
        private IContactRepository addressRepository;
        public AddressService(IContactRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public List<Address> GetAddress(Contact c)
        {
            return addressRepository.GetAddress(c);
        }
        public List<Address> SearchAddress(string name)
        {
            return addressRepository.SearchAddress(name);
        }
        public void AddAddress(Contact c,Address address)
        {
            addressRepository.AddAddress(c,address);
        }
        public void EditContact(int idOfContact,int idOfAddress, string Modification)
        {
            addressRepository.EditAddress(idOfContact, idOfAddress, Modification);
        }
        public void DeleteAddress(int idOfAddress)
        {
            addressRepository.DeleteAddress(idOfAddress);
        }

        public void DeleteAllAddress(Contact c)
        {
            addressRepository.DeleteAllAddress(c);
        }

    }
}
