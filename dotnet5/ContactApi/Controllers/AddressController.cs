
using ContactApp.Data.Repository;
using ContactApp.Domain.DTO;
using ContactApp.Domain.Models;
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

        private readonly IContactRepository _contactRepository;
        public AddressController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }


        


        [HttpPost]
        [Route("tenants/{tenantId}/user/{userId}/contact/{contactId}/address")]
        public IActionResult AddContactAddress(string tenantId,string userId,string contactId, [FromBody] AddressDTO addressDTO)
        {
            if (ModelState.IsValid)
            {
                bool isAddressAdded = _contactRepository.AddContactAddress(Guid.Parse(contactId), addressDTO);
                if (isAddressAdded)
                {
                    return Ok("address successfully");
                }
                else
                {
                    return BadRequest("cannot  add address");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/addresses")]
        public List<Address> GetUserContactAddresses(string tenantId, string userId, string contactId)
        {
            return _contactRepository.GetUserContactAddresses(Guid.Parse(tenantId), Guid.Parse(userId), Guid.Parse(contactId)).ToList();
        }


        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/addresses/{addressId}")]
        public Address GetUserContactAddresses(string tenantId, string userId, string contactId,string addressId)
        {
            return _contactRepository.GetUserContactAddressById( Guid.Parse(contactId),Guid.Parse(addressId));
        }


        [HttpDelete]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/address/{addressId}")]
        public IActionResult DeleteAddress(string tenantId, string userId, string contactId,string addressId)
        {
            if (ModelState.IsValid)
            {
                bool isAddressDeleted = _contactRepository.DeleteAddress(Guid.Parse(tenantId), Guid.Parse(userId), Guid.Parse(contactId),Guid.Parse(addressId));
                if (isAddressDeleted)
                {
                    return Ok("address deleted successfully");
                }
                else
                {
                    return BadRequest("Cannot delete address");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpPut]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}/address")]
        public IActionResult UpdateAddress(string tenantId, string userId, string contactId ,[FromBody] Address address)
        {
            if (ModelState.IsValid)
            {
                bool isAddressUpdated = _contactRepository.UpdateAddress(Guid.Parse(tenantId), Guid.Parse(userId),Guid.Parse(contactId), address);
                if (isAddressUpdated)
                {
                    return Ok("address updated successfully");
                }
                else
                {
                    return BadRequest("Cannot update address");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

    }
}
