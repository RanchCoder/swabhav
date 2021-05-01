//using ContactApp.Domain.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ContactApp.Data.DBContext;
//using ContactApp.Domain.DTO;
//using System.Security.Cryptography;
//using Microsoft.EntityFrameworkCore;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System.Security.Claims;

//namespace ContactApp.Data.Repository
//{
//    public class ContactRepository : IContactRepository
//    {
//        private const int ValidCountForTenantAccount = 1,ValidCountForUserAccount = 1;
//        private const int ValidCountForUserAccountPresence = 1;
//        const bool OperationSuccess = true, OperationFailure = false;
//        const string Admin = "Admin", User = "User";
//        const int ValidCompanyNameCount = 1;
//        private readonly ContactAddressDBContext _contactAddressDBContext;
//        private readonly AppSettings _appSettings;
//        private readonly EncryptorDecryptor _encryptorDecryptor;
//        public ContactRepository(ContactAddressDBContext contactAddressDBContext,IOptions<AppSettings> appSettings,EncryptorDecryptor encryptorDecryptor)
//        {
//            _appSettings = appSettings.Value;
//            _encryptorDecryptor = encryptorDecryptor;
//            _contactAddressDBContext = contactAddressDBContext;
//        }
//        public IQueryable<Contact> GetContacts()
//        {
//           return _contactAddressDBContext.Contacts.Include(contact=>contact.Addresses).AsQueryable<Contact>();


//        }

//        public IQueryable<Address> GetUserContactAddresses(Guid tenantId,Guid userId,Guid contactId)
//        {
//            return  _contactAddressDBContext.Addresses.Where(user=>user.ContactID == contactId &&
//            user.Contact.User.UserId == userId &&
//            user.Contact.User.Tenant.TenantId == tenantId);

           
//        }

//        public IQueryable<User> GetUserRole(Guid tenantId,Guid userId)
//        {
//            return _contactAddressDBContext.Users.Where(user=>user.TenantId == tenantId && user.UserId == userId);
//        }

//        public IQueryable<Tenant> GetTenants()
//        {
//            return _contactAddressDBContext.Tenants;
//        }

//        public Tenant GetTenantById(Guid tenantId)
//        {
//            return _contactAddressDBContext.Tenants.Where(tenant => tenant.TenantId == tenantId).FirstOrDefault();
//        }

//        public async Task<bool> UpdateTenant(Guid tenantId, Tenant tenantToUpdate)
//        {
//            try
//            {
//                foreach (var tenant in _contactAddressDBContext.Tenants.Where(itemTenant => itemTenant.TenantId == tenantId))
//                {
//                    tenant.CompanyName = tenantToUpdate.CompanyName;
//                    tenant.CompanyStrength = tenantToUpdate.CompanyStrength;
//                }
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }catch(Exception ex)
//            {
//                return OperationFailure;
//            }
            
//        }

//        public async Task<bool> DeleteTenant(Guid tenantId)
//        {
//            var tenantToDelete = _contactAddressDBContext.Tenants.Where(tenant => tenant.TenantId == tenantId).FirstOrDefault();
//            if(tenantToDelete != null)
//            {
//                _contactAddressDBContext.Remove(tenantToDelete);
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }
//            else
//            {
//                return OperationFailure;
//            }
//        }

//        public IQueryable<User> GetUsers()
//        {
//            return _contactAddressDBContext.Users;
//        }

//        public User GetUserById(Guid tenantId,Guid userId)
//        {
//            return _contactAddressDBContext.Users.Where(user => user.UserId == userId && user.TenantId == tenantId).FirstOrDefault();
//        }

//        public IQueryable<Contact> GetUserContacts(Guid tenantId, Guid userId)
//        {
            
//            return _contactAddressDBContext.Contacts.Where(contact => contact.UserId == userId);
            
//        }

//        public async Task<Contact> GetUserContactById(Guid tenantId, Guid userId, Guid contactId)
//        {
//            return await _contactAddressDBContext.Contacts.Where(contact => contact.Id == contactId && contact.UserId == userId && contact.User.TenantId == tenantId).FirstOrDefaultAsync();

//        }

//        public async Task<bool> RegisterTenantUser(Guid tenantId, User userToBeAdded)
//        {
//            try
//            {
//                User user = new User()
//                {
//                    UserId = new Guid(),
//                    Username = userToBeAdded.Username,
//                    Password = _encryptorDecryptor.Encrypt(userToBeAdded.Password),
//                    Role = Admin,
//                    TenantId = tenantId,
//                    Email = userToBeAdded.Email,
//                };
//                _contactAddressDBContext.Users.Add(user);

//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;

//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }


//        }


//        public async Task<bool> AddTenantUser(Guid tenantId,User userToBeAdded )
//        {
//            try
//            {
//                User user = new User()
//                {
//                    UserId = new Guid(),
//                    Username = userToBeAdded.Username,
//                    Password = _encryptorDecryptor.Encrypt(userToBeAdded.Password),
//                    Role = userToBeAdded.Role,
//                    TenantId = tenantId,
//                    Email = userToBeAdded.Email,
//                };
//                _contactAddressDBContext.Users.Add(user);

//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;

//            }
//            catch(Exception ex)
//            {
//                return OperationFailure;
//            }
            

//         }

//        public async Task<bool> AddTenant(Tenant tenantToAdd)
//        {
//            try
//            {
//                Tenant tenant = new Tenant()
//                {
//                    TenantId = new Guid(),
//                    CompanyName = tenantToAdd.CompanyName,
//                    CompanyStrength = tenantToAdd.CompanyStrength,
//                };
//                _contactAddressDBContext.Tenants.Add(tenant);

//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;

//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }


//        }

//        public async Task<bool> AddContactAddress(Guid tenantId,Guid userId,Guid contactId, AddressDTO addressDTO)
//        {
//            try
//            {
//                Address addressToAdd = new Address()
//                {
//                    Id = new Guid(),
//                    City = addressDTO.City,
//                    State = addressDTO.State,
//                    Country = addressDTO.Country,
//                    ContactID = contactId,
                    
//                };
//                _contactAddressDBContext.Addresses.Add(addressToAdd);
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }catch(Exception ex)
//            {
//                return OperationFailure;
//            }
            


//        }

        

//        public Address GetUserContactAddressById(Guid contactId, Guid addressId)
//        {
//            return _contactAddressDBContext.Addresses.Where(address => address.Id == addressId && address.ContactID == contactId).FirstOrDefault();
//        }

//        public IQueryable<User> GetUsers(Guid tenantId)
//        {
//            return _contactAddressDBContext.Users.Where(user => user.TenantId == tenantId);
//        }

//        public async Task<bool> AddContact(Guid userId, Contact contact)
//        {
//            try
//            {
//                Contact contactToAdd = new Contact()
//                {
//                    Id = new Guid(),
//                    FirstName = contact.FirstName,
//                    LastName = contact.LastName,
//                    PhoneNumber = contact.PhoneNumber,
//                    UserId = userId,
//                };
//                _contactAddressDBContext.Contacts.Add(contactToAdd);
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }

//        }

//        public async Task<bool> UpdateContact(Guid tenantId, Guid userId, Contact contact)
//        {
//            try
//            {
//                //var contactToUpdate = _contactAddressDBContext.Contacts.Where(con => con.Id == contact.Id && con.UserId == userId && con.User.TenantId == tenantId).FirstOrDefault();

//                //Console.WriteLine(contactToUpdate);

//                foreach (var contactToUpdate in _contactAddressDBContext.Contacts.Where(con => con.Id == contact.Id && con.UserId == userId && con.User.TenantId == tenantId))
//                {
//                    contactToUpdate.FirstName = contact.FirstName;
//                    contactToUpdate.LastName = contact.LastName;
//                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
//                }
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }
            
//        }

//        public async Task<bool> DeleteContact(Guid tenantId, Guid userId,Guid contactId)
//        {
//            try
//            {
//                var contactToDelete =await _contactAddressDBContext.Contacts.Where(contact => contact.Id == contactId && contact.UserId == userId && contact.User.TenantId == tenantId).FirstOrDefaultAsync();
//                if(contactToDelete != null)
//                {
//                   var entityRemoved =  _contactAddressDBContext.Contacts.Remove(contactToDelete);
//                    if(entityRemoved != null)
//                    {
//                        await _contactAddressDBContext.SaveChangesAsync();
//                        return OperationSuccess;
//                    }
//                    else
//                    {
//                        return OperationFailure;
//                    }
//                }
//                else
//                {
//                    return OperationFailure;
//                }
//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }

//        }

//        public async Task<bool> DeleteAddress(Guid tenantId, Guid userId, Guid contactId,Guid addressId)
//        {
//            try
//            {
//                var addressToDelete = await _contactAddressDBContext.Addresses.Where(
//                    address=>address.Id == addressId &&
//                    address.ContactID == contactId &&
//                    address.Contact.UserId == userId &&
//                    address.Contact.User.TenantId == tenantId)
//                    .FirstOrDefaultAsync();
//                if (addressToDelete != null)
//                {
//                    var entityRemoved = _contactAddressDBContext.Addresses.Remove(addressToDelete);
//                    if (entityRemoved != null)
//                    {
//                        await _contactAddressDBContext.SaveChangesAsync();
//                        return OperationSuccess;
//                    }
//                    else
//                    {
//                        return OperationFailure;
//                    }
//                }
//                else
//                {
//                    return OperationFailure;
//                }
//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }

//        }


//        public async Task<bool> UpdateAddress(Guid tenantId, Guid userId,Guid contactId, Address addressToUpdate)
//        {
//            try
//            {

//                foreach (var address in _contactAddressDBContext.Addresses.Where(
//                    addressItem=>addressItem.Id == addressToUpdate.Id 
//                    && addressItem.ContactID == contactId 
//                    && addressItem.Contact.UserId == userId 
//                    && addressItem.Contact.User.TenantId == tenantId))
//                {
//                    address.City = addressToUpdate.City;
//                    address.State = addressToUpdate.State;
//                    address.Country = addressToUpdate.Country;
//                }
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }
//            catch (Exception ex)
//            {
//                return OperationFailure;
//            }

//        }

//        public async Task<bool> UpdateUser(Guid tenantId, Guid userId, User userToUpdate)
//        {
//            try
//            {
//                foreach (var user in _contactAddressDBContext.Users.Where(itemUser => itemUser.UserId == userId && itemUser.TenantId == tenantId))
//                {
//                    user.Email = userToUpdate.Email;
//                    user.Username = userToUpdate.Username;
//                    user.Password = _encryptorDecryptor.Encrypt(userToUpdate.Password);
//                    user.Role = userToUpdate.Role;
//                }

//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;
//            }catch(Exception ex)
//            {
//                return OperationFailure;
//            }
            
//        }

//        public async Task<bool> DeleteUser(Guid tenantId, Guid userId)
//        {
//            var userToBeDeleted =await _contactAddressDBContext.Users.Where(user=>user.TenantId == tenantId && user.UserId == userId).FirstOrDefaultAsync();
//            if(userToBeDeleted == null)
//            {
//                return OperationFailure;
//            }
//            else{
//                _contactAddressDBContext.Users.Remove(userToBeDeleted);
//                await _contactAddressDBContext.SaveChangesAsync();
//                return OperationSuccess;

//            }
//        }

       

//        public async Task<User> AuthenticateUser(string email, string password)
//        {
//            var userAccount =await _contactAddressDBContext.Users.FirstOrDefaultAsync(user => user.Email == email && _encryptorDecryptor.Decrypt(user.Password) == password);
//            if (userAccount == null)
//            {
//                return null;
//            }
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[] {
//                    new Claim(ClaimTypes.Name, userAccount.Username)
//                }),
//                Expires = DateTime.UtcNow.AddHours(1),
//                SigningCredentials = new SigningCredentials(
//                    new SymmetricSecurityKey(key),
//                    SecurityAlgorithms.HmacSha256Signature
//                    )
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            userAccount.Token = tokenHandler.WriteToken(token);
//            userAccount.Password = null;
//            return userAccount;
//        }

//        public async Task<int> GetCompanyNameCount(string companyName)
//        {
//            return await _contactAddressDBContext.Tenants.Where(tenant=> tenant.CompanyName.ToLower() == companyName.ToLower()).CountAsync();
//        }

//        public async Task<IQueryable<Tenant>> GetTenantIdByCompanyName(string companyName)
//        {
//            int companyNameCount =await GetCompanyNameCount(companyName);
//            if(companyNameCount == ValidCompanyNameCount)
//            {
//                return  _contactAddressDBContext.Tenants.Where(tenant=>tenant.CompanyName == companyName);
//            }
//            else
//            {
//                return null;
//            }
//        }

        

//        public async Task<bool> ValidUserAccount(Guid tenantId,string userEmail,string userPassword) 
//        {
//            string password = _encryptorDecryptor.Encrypt(userPassword);
//            var numberOfUserAccount =await _contactAddressDBContext.Users.Where(user => user.TenantId == tenantId && user.Email == userEmail && user.Password == password).CountAsync();
//            if(numberOfUserAccount == ValidCountForUserAccount)
//            {
//                return OperationSuccess;
//            }
//            else{
//                return OperationFailure;
//            }
//        }

//        public IQueryable<User> FetchUserAccount(Guid tenantId, string userEmail)
//        {
//            return _contactAddressDBContext.Users.Where(user => user.TenantId == tenantId && user.Email == userEmail );
//        }

//        public IQueryable<User> GetCountForEmailProvided(string email)
//        {
//            return _contactAddressDBContext.Users.Where(user=>user.Email == email);
//        }

//        public IQueryable<User> GetUsersCount(Guid tenantId)
//        {
//            return _contactAddressDBContext.Users.Where(user => user.TenantId == tenantId);
//        }

//        public  IQueryable<Contact> GetContactsCount(Guid tenantId)
//        {
//            return  _contactAddressDBContext.Contacts.Where(contact=>contact.User.TenantId == tenantId);
//        }

//        public IQueryable<Address> GetAddressCount(Guid tenantId)
//        {
//            return _contactAddressDBContext.Addresses.Where(address => address.Contact.User.TenantId == tenantId);
//        }

//        public  IQueryable<Tenant> GetCompanyStrength(Guid tenantId)
//        {
//            return  _contactAddressDBContext.Tenants.Where(tenant => tenant.TenantId == tenantId);
//        }
//    }
//}
