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
        private readonly IAsyncContactRepository<Contact> _contactRepository;
        private readonly IAsyncContactRepository<Tenant> _tenantRepository;
        private readonly IAsyncContactRepository<User> _userRepository;
        public ContactController(IAsyncContactRepository<Contact> contactRepository,
            IAsyncContactRepository<Tenant> tenantRepository,
            IAsyncContactRepository<User> userRepository)
        {
            this._contactRepository = contactRepository;
            this._tenantRepository = tenantRepository;
            this._userRepository = userRepository;
        }

           


        
        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts")]
        public async Task<ActionResult<List<Contact>>> GetUserContact(string tenantId, string userId)
        {
            if(_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }

            return await _contactRepository.GetWhere(x=> x.UserId == Guid.Parse(userId) && x.User.TenantId == Guid.Parse(tenantId));

            
        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}")]
        public async Task<ActionResult<Contact>> GetUserContactById(string tenantId, string userId, string contactId)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if(_contactRepository.GetById(Guid.Parse(contactId)) == null)
            {
                return BadRequest("contact id is not valid");
            }

            return Ok(await _contactRepository.GetById(Guid.Parse(contactId)));

        }


        [HttpPost]
        [Route("tenants/{tenantId}/users/{userId}/contacts")]
        public async Task<ActionResult> AddUserContact(string tenantId, string userId, [FromBody] ContactDTO contactDTO)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (_userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }

            if (ModelState.IsValid)
            {
                Contact contact = await _contactRepository.FirstOrDefault(con=> con.PhoneNumber == contactDTO.PhoneNumber);
                if (contact == null)

                {
                    await _contactRepository.Add(new Contact { FirstName = contactDTO.FirstName, LastName = contactDTO.LastName,PhoneNumber = contactDTO.PhoneNumber,UserId = Guid.Parse(userId)}) ;
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
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}")]
        public async Task<ActionResult> UpdateContact(string tenantId, string userId,string contactId, [FromBody] ContactDTO contactDTO)
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
                Contact contact = await _contactRepository.GetById(Guid.Parse(contactId));
                contact.FirstName = contactDTO.FirstName;
                contact.LastName = contactDTO.LastName;
                contact.PhoneNumber = contactDTO.PhoneNumber;
                 await _contactRepository.Update(contact);
                return Ok("Contact updated successfully");
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpDelete]
        [Route("tenants/{tenantId}/users/{userId}/contacts/{contactId}")]
        public async Task<ActionResult> DeleteContact(string tenantId, string userId, string contactId)
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

            Contact contact =await _contactRepository.GetById(Guid.Parse(contactId));
            
            await _contactRepository.Remove(contact);
            return Ok("Contact Deleted Successfully");

        }


    }
}
