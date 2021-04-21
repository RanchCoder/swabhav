using ContactApp.Data.Repository;
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
    public class UserController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;
        public UserController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }


        [HttpGet]
        [Route("tenants/{tenantId}/users")]
        public List<User> GetUsers(string tenantId)
        {
            return _contactRepository.GetUsers(Guid.Parse(tenantId)).ToList();
        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}")]
        public User GetUser(string tenantId, string userId)
        {
            return _contactRepository.GetUserById(Guid.Parse(tenantId), Guid.Parse(userId));
        }


      

        [HttpPost]
        [Route("tenants/{tenantId}/users/register")]
        public IActionResult AddTenantUser(string tenantId, [FromBody] UserCredentials userCredential)
        {
            if (ModelState.IsValid)
            {
                bool isUserAdded = _contactRepository.AddTenantUser(Guid.Parse(tenantId), userCredential);
                if (isUserAdded)
                {
                    return Ok("User added successfully");
                }
                else
                {
                    return BadRequest("Cannot add user");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }


    }
}
