//using ContactApp.Domain.Models;
//using ContactApp.Domain.DTO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ContactApp.Data.Repository
//{
//    public interface IContactRepository
//    {
//        IQueryable<Contact>  GetContacts();
//        IQueryable<Address> GetUserContactAddresses(Guid tenantId,Guid userId,Guid contactId);
//        IQueryable<Tenant> GetTenants();
//        Tenant GetTenantById(Guid tenantId);

//        IQueryable<User> FetchUserAccount(Guid tenantId,string userEmail);
//        Task<int> GetCompanyNameCount(string companyName);

//        Task<IQueryable<Tenant>> GetTenantIdByCompanyName(string companyName);

//        Task<bool> UpdateTenant(Guid tenantId, Tenant tenant);
//        Task<bool> DeleteTenant(Guid tenantId);
//        IQueryable<User> GetUsers(Guid tenantId);
//        User GetUserById(Guid tenantId,Guid userId);

//        Task<bool> UpdateUser(Guid tenantId, Guid userId, User userToUpdate);
//        Task<bool> DeleteUser(Guid tenantId,Guid userId);

//        IQueryable<Contact> GetUserContacts(Guid tenantId,Guid userId);
//        Task<Contact> GetUserContactById(Guid tenantId,Guid userId,Guid contactId);

//        Task<bool> UpdateContact(Guid tenantId,Guid userId,Contact contact);
//        Task<bool> AddContact(Guid userId,Contact contact);

//        Task<bool> DeleteContact(Guid tenantId,Guid userId,Guid contactId);
//        Task<bool> AddTenantUser(Guid tenantId,User user);

//        Task<bool> AddTenant(Tenant tenant);
//        Task<bool> AddContactAddress(Guid tenantId,Guid userId,Guid contactId,AddressDTO address);

//        Address GetUserContactAddressById(Guid contactId,Guid addressId);

//        Task<bool> DeleteAddress(Guid tenantId,Guid userId,Guid contactId, Guid addressId);

//        Task<bool> UpdateAddress(Guid tenantId, Guid userId, Guid contactId, Address address);

        
//        Task<User>  AuthenticateUser(string email, string password);

//        IQueryable<User> GetUserRole(Guid tenantId,Guid userId);
//        Task<bool> RegisterTenantUser(Guid tenantId, User userToBeAdded);

//        Task<bool> ValidUserAccount(Guid tenantId,string userEmail,string userPassword);
//        IQueryable<User> GetCountForEmailProvided(string email);

//        IQueryable<User> GetUsersCount(Guid tenantId);
//        //IQueryable<Contact> GetContactsCount(Guid tenantId);
//        IQueryable<Address> GetAddressCount(Guid tenantId);

//        IQueryable<Tenant> GetCompanyStrength(Guid tenantId);
//    }
//}
