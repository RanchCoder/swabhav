using ContactAddressMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressMVCApp.Repository
{
    public interface IAddressRepository
    {
        List<Address> GetAddress(Contact c);
        List<Address> SearchAddress(string name);
        void AddAddress(Contact contact, Address address);
        bool EditAddress(int idOfContact, int idOfAddress, string Modification);
        void DeleteAddress(int idOfContact);
        void DeleteAllAddress(Contact contact);

        Address GetAddressById(int id);
        bool IntializeAddress();

    }
}
