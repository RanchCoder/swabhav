using ContactApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Data.DBContext;
using ContactApp.Domain.DTO;
using Microsoft.EntityFrameworkCore;
namespace ContactApp.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        private const int ValidCountForTenantAccount = 1;
        private const int ValidCountForUserAccountPresence = 1;
        const bool OperationSuccess = true, OperationFailure = false;
        private readonly ContactAddressDBContext _contactAddressDBContext;
        public ContactRepository(ContactAddressDBContext contactAddressDBContext)
        {
            _contactAddressDBContext = contactAddressDBContext;
        }
        public IQueryable<Contact> GetContacts()
        {
           return _contactAddressDBContext.Contacts.Include(contact=>contact.Addresses).AsQueryable<Contact>();


        }

        public IQueryable<Address> GetUserContactAddresses(Guid tenantId,Guid userId,Guid contactId)
        {
            return _contactAddressDBContext.Addresses.Where(user=>user.ContactID == contactId &&
            user.Contact.User.UserId == userId &&
            user.Contact.User.Tenant.TenantId == tenantId);

           
        }

        public IQueryable<Tenant> GetTenants()
        {
            return _contactAddressDBContext.Tenants;
        }

        public Tenant GetTenantById(Guid tenantId)
        {
            return _contactAddressDBContext.Tenants.Where(tenant => tenant.TenantId == tenantId).FirstOrDefault();
        }

        public IQueryable<User> GetUsers()
        {
            return _contactAddressDBContext.Users;
        }

        public User GetUserById(Guid tenantId,Guid userId)
        {
            return _contactAddressDBContext.Users.Where(user => user.UserId == userId && user.TenantId == tenantId).FirstOrDefault();
        }

        public IQueryable<Contact> GetUserContacts(Guid tenantId, Guid userId)
        {
            
            return _contactAddressDBContext.Contacts.Where(contact => contact.UserId == userId);
            
        }

        public Contact GetUserContactById(Guid tenantId, Guid userId, Guid contactId)
        {
            return _contactAddressDBContext.Contacts.Where(contact => contact.Id == contactId && contact.UserId == userId && contact.User.TenantId == tenantId).FirstOrDefault();

        }

        public bool AddTenantUser(Guid tenantId,UserCredentials userCredentials )
        {
            try
            {
                User user = new User()
                {
                    UserId = new Guid(),
                    Username = userCredentials.Username,
                    Password = userCredentials.Password,
                    TenantId = tenantId
                };
                _contactAddressDBContext.Users.Add(user);

                _contactAddressDBContext.SaveChanges();
                return OperationSuccess;

            }
            catch(Exception ex)
            {
                return OperationFailure;
            }
            

         }

        public bool AddTenant(string tenantName)
        {
            try
            {
                Tenant tenant = new Tenant()
                {
                    TenantId = new Guid(),
                    TenantName = tenantName,
                };
                _contactAddressDBContext.Tenants.Add(tenant);

                _contactAddressDBContext.SaveChanges();
                return OperationSuccess;

            }
            catch (Exception ex)
            {
                return OperationFailure;
            }


        }

        public bool AddContactAddress(Guid contactId, AddressDTO addressDTO)
        {
            try
            {
                Address addressToAdd = new Address()
                {
                    Id = new Guid(),
                    City = addressDTO.City,
                    State = addressDTO.State,
                    Country = addressDTO.Country,
                    ContactID = addressDTO.ContactID,
                };
                _contactAddressDBContext.Addresses.Add(addressToAdd);
                _contactAddressDBContext.SaveChanges();
                return OperationSuccess;
            }catch(Exception ex)
            {
                return OperationFailure;
            }
            


        }

        

        public Address GetUserContactAddressById(Guid contactId, Guid addressId)
        {
            return _contactAddressDBContext.Addresses.Where(address => address.Id == addressId && address.ContactID == contactId).FirstOrDefault();
        }

        public IQueryable<User> GetUsers(Guid tenantId)
        {
            return _contactAddressDBContext.Users.Where(user => user.TenantId == tenantId);
        }

        public bool AddContact(Guid userId, Contact contact)
        {
            try
            {
                Contact contactToAdd = new Contact()
                {
                    Id = new Guid(),
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber,
                    UserId = userId,
                };
                _contactAddressDBContext.Contacts.Add(contactToAdd);
                _contactAddressDBContext.SaveChanges();
                return OperationSuccess;
            }
            catch (Exception ex)
            {
                return OperationFailure;
            }

        }

        public bool UpdateContact(Guid tenantId, Guid userId, Contact contact)
        {
            try
            {
                //var contactToUpdate = _contactAddressDBContext.Contacts.Where(con => con.Id == contact.Id && con.UserId == userId && con.User.TenantId == tenantId).FirstOrDefault();

                //Console.WriteLine(contactToUpdate);

                foreach (var contactToUpdate in _contactAddressDBContext.Contacts.Where(con => con.Id == contact.Id && con.UserId == userId && con.User.TenantId == tenantId))
                {
                    contactToUpdate.FirstName = contact.FirstName;
                    contactToUpdate.LastName = contact.LastName;
                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
                }
                _contactAddressDBContext.SaveChanges();
                return OperationSuccess;
            }
            catch (Exception ex)
            {
                return OperationFailure;
            }
            
        }

        public bool DeleteContact(Guid tenantId, Guid userId,Guid contactId)
        {
            try
            {
                var contactToDelete = _contactAddressDBContext.Contacts.Where(contact => contact.Id == contactId && contact.UserId == userId && contact.User.TenantId == tenantId).FirstOrDefault();
                if(contactToDelete != null)
                {
                   var entityRemoved =  _contactAddressDBContext.Contacts.Remove(contactToDelete);
                    if(entityRemoved != null)
                    {
                        _contactAddressDBContext.SaveChanges();
                        return OperationSuccess;
                    }
                    else
                    {
                        return OperationFailure;
                    }
                }
                else
                {
                    return OperationFailure;
                }
            }
            catch (Exception ex)
            {
                return OperationFailure;
            }

        }

        public bool DeleteAddress(Guid tenantId, Guid userId, Guid contactId,Guid addressId)
        {
            try
            {
                var addressToDelete = _contactAddressDBContext.Addresses.Where(
                    address=>address.Id == addressId &&
                    address.ContactID == contactId &&
                    address.Contact.UserId == userId &&
                    address.Contact.User.TenantId == tenantId)
                    .FirstOrDefault();
                if (addressToDelete != null)
                {
                    var entityRemoved = _contactAddressDBContext.Addresses.Remove(addressToDelete);
                    if (entityRemoved != null)
                    {
                        _contactAddressDBContext.SaveChanges();
                        return OperationSuccess;
                    }
                    else
                    {
                        return OperationFailure;
                    }
                }
                else
                {
                    return OperationFailure;
                }
            }
            catch (Exception ex)
            {
                return OperationFailure;
            }

        }


        public bool UpdateAddress(Guid tenantId, Guid userId,Guid contactId, Address addressToUpdate)
        {
            try
            {

                foreach (var address in _contactAddressDBContext.Addresses.Where(
                    addressItem=>addressItem.Id == addressToUpdate.Id 
                    && addressItem.ContactID == contactId 
                    && addressItem.Contact.UserId == userId 
                    && addressItem.Contact.User.TenantId == tenantId))
                {
                    address.City = addressToUpdate.City;
                    address.State = addressToUpdate.State;
                    address.Country = addressToUpdate.Country;
                }
                _contactAddressDBContext.SaveChanges();
                return OperationSuccess;
            }
            catch (Exception ex)
            {
                return OperationFailure;
            }

        }


        //public bool AddTenantUser(Guid tenantId,User user)
        //{
        //    int tenantCount = _contactAddressDBContext.Tenants.Where(tenant=>tenant.TenantId == tenantId).Count();
        //    if(tenantCount == ValidCountForTenantAccount)            
        //    {

        //        _contactAddressDBContext.Users.Add(user);
        //    }
        //}
    }
}
