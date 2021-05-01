
using ContactApp.Data.Repository;
using ContactApp.Domain.DTO;
using ContactApp.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAsyncContactRepository<Contact> _contactRepository;
        private readonly IAsyncContactRepository<Tenant> _tenantRepository;
        private readonly IAsyncContactRepository<User> _userRepository;
        private readonly IAsyncContactRepository<Address> _addressRepository;
        public AddressController(
            IAsyncContactRepository<Contact> contactRepository,
            IAsyncContactRepository<Tenant> tenantRepository,
            IAsyncContactRepository<User> userRepository,
            IAsyncContactRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
        }

        
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/address")]
        public async Task<IActionResult> PostAddress(string tenantId, string userId, string contactId, [FromBody] AddressDTO addressDTO)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (await _userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if (await _contactRepository.GetById(Guid.Parse(contactId)) == null)
            {
                return BadRequest("contact id is not valid");
            }


            if (ModelState.IsValid)
            {
                Address address = await _addressRepository.FirstOrDefault(address=>address.ContactID == Guid.Parse(contactId) && address.City == addressDTO.City);
                if(address == null)
                {
                    
                    await _addressRepository.Add(new Address { 
                        Id = new Guid(),
                        City = addressDTO.City,
                        ContactID = Guid.Parse(contactId),
                        State = addressDTO.State,
                        Country = addressDTO.Country
                    });

                    return Ok("Address added successfully");
                }
                else
                {
                    return BadRequest("Cannot add address");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/addresses")]
        public async Task<ActionResult<List<Address>>> GetUserContactAddresses(string tenantId, string userId, string contactId)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if (_contactRepository.GetById(Guid.Parse(contactId)) == null)
            {
                return BadRequest("contact id is not valid");
            }

            return await _addressRepository.GetWhere(address=>address.Contact.User.Id == Guid.Parse(userId) && address.ContactID == Guid.Parse(contactId));
        }


        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/addresses/{addressId}")]
        public async  Task<ActionResult<Address>> GetUserContactAddresses(string tenantId, string userId, string contactId, string addressId)
        {

            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if (_contactRepository.GetById(Guid.Parse(contactId)) == null)
            {
                return BadRequest("contact id is not valid");
            }

            if (_addressRepository.GetById(Guid.Parse(addressId)) == null)
            {
                return BadRequest("address id is not valid");
            }


            return await _addressRepository.FirstOrDefault(address =>
            address.Id == Guid.Parse(addressId) &&
            address.ContactID == Guid.Parse(contactId) &&
            address.Contact.UserId == Guid.Parse(userId)
            );
        }


        [HttpDelete]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/address/{addressId}")]
        public async Task<IActionResult> DeleteAddress(string tenantId, string userId, string contactId, string addressId)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if (_contactRepository.GetById(Guid.Parse(contactId)) == null)
            {
                return BadRequest("contact id is not valid");
            }
            if (_addressRepository.GetById(Guid.Parse(addressId)) == null)
            {
                return BadRequest("address id is not valid");
            }
            Address addressToDelete = await _addressRepository.FirstOrDefault(addressItem =>
                                                                                         addressItem.Id == Guid.Parse(addressId) &&
                                                                                         addressItem.ContactID == Guid.Parse(contactId) &&
                                                                                         addressItem.Contact.UserId == Guid.Parse(userId)
                                                                                   );

            await _addressRepository.Remove(addressToDelete);
            return Ok("Address deleted successfully");


        }

        [HttpPut]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/address")]
        public async Task<IActionResult> UpdateAddress(string tenantId, string userId, string contactId, [FromBody] Address address)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if (_contactRepository.GetById(Guid.Parse(contactId)) == null)
            {
                return BadRequest("contact id is not valid");
            }

            if (ModelState.IsValid)
            {
                Address addressToUpdate = await _addressRepository.FirstOrDefault(addressItem =>
                                                                                         addressItem.Id == address.Id &&
                                                                                         addressItem.ContactID == Guid.Parse(contactId) &&
                                                                                         addressItem.Contact.UserId == Guid.Parse(userId)
                                                                                   );
                addressToUpdate.City = address.City;
                addressToUpdate.State = address.State;
                addressToUpdate.Country = address.Country;

                await _addressRepository.Update(addressToUpdate);
                return Ok("Successfully updated the address");
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

    }
}
