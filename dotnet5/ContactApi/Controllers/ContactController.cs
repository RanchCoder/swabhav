using ContactApp.Data.DBContext;
using ContactApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Data.Repository;
using ContactApi.DTO;

namespace ContactApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

           

        
        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts")]
        public List<Contact> GetUserContact(string tenantId, string userId)
        {
            return _contactRepository.GetUserContacts(Guid.Parse(tenantId), Guid.Parse(userId)).ToList();
        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}")]
        public Contact GetUserContactById(string tenantId, string userId,string contactId)
        {
            return _contactRepository.GetUserContactById(Guid.Parse(tenantId), Guid.Parse(userId),Guid.Parse(contactId));
        }


        [HttpPost]
        [Route("tenants/{tenantId}/users/{userId}/contacts")]
        public IActionResult AddUserContact(string tenantId,string userId, [FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool isUserAdded = _contactRepository.AddContact(Guid.Parse(userId), contact);
                if (isUserAdded)
                {
                    return Ok("contact added successfully");
                }
                else
                {
                    return BadRequest("Cannot add contact");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpPut]
        [Route("tenants/{tenantId}/users/{userId}/contacts")]
        public IActionResult UpdateContact(string tenantId, string userId, [FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool isContactUpdated = _contactRepository.UpdateContact(Guid.Parse(tenantId),Guid.Parse(userId), contact);
                if (isContactUpdated)
                {
                    return Ok("contact updated successfully");
                }
                else
                {
                    return BadRequest("Cannot update contact");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpDelete]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}")]
        public IActionResult DeleteContact(string tenantId, string userId,string contactId)
        {
            if (ModelState.IsValid)
            {
                bool isContactDeleted = _contactRepository.DeleteContact(Guid.Parse(tenantId), Guid.Parse(userId), Guid.Parse(contactId));
                if (isContactDeleted)
                {
                    return Ok("contact deleted successfully");
                }
                else
                {
                    return BadRequest("Cannot delete contact");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }


    }
}
