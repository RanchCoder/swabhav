using ContactApp.Domain.Models;
using ContactApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Data.Repository
{
    public interface IContactRepository
    {
        IQueryable<Contact>  GetContacts();
        IQueryable<Address> GetUserContactAddresses(Guid tenantId,Guid userId,Guid contactId);
        IQueryable<Tenant> GetTenants();
        Tenant GetTenantById(Guid tenantId);

        IQueryable<User> GetUsers(Guid tenantId);
        User GetUserById(Guid tenantId,Guid userId);

        IQueryable<Contact> GetUserContacts(Guid tenantId,Guid userId);
        Contact GetUserContactById(Guid tenantId,Guid userId,Guid contactId);

        bool UpdateContact(Guid tenantId,Guid userId,Contact contact);
        bool AddContact(Guid userId,Contact contact);

        bool DeleteContact(Guid tenantId,Guid userId,Guid contactId);
        bool AddTenantUser(Guid tenantId,UserCredentials userCredentials);

        bool AddTenant(string tenantName);
        bool AddContactAddress(Guid contactId,AddressDTO address);

        Address GetUserContactAddressById(Guid contactId,Guid addressId);

        bool DeleteAddress(Guid tenantId,Guid userId,Guid contactId, Guid addressId);

        bool UpdateAddress(Guid tenantId, Guid userId, Guid contactId, Address address);

        
        
    }
}
