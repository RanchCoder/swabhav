using ContactApp.Data.Repository;
using ContactApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApi.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ContactApi.Token;

namespace ContactApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAsyncContactRepository<User> _userRepository;
        private readonly IAsyncContactRepository<Tenant> _tenantRepository;
        private readonly EncryptorDecryptor _encryptorDecryptor;
        public UserController(IAsyncContactRepository<User> userRepository,IAsyncContactRepository<Tenant> tenantRespository,EncryptorDecryptor encryptorDecryptor)
        {
            _encryptorDecryptor = encryptorDecryptor;
            _tenantRepository = tenantRespository;
            _userRepository = userRepository;
        }


        [HttpGet]
        [JwtAuthorization]
        [Route("tenants/{tenantId}/users")]
        
        

        public async  Task<ActionResult<List<User>>> GetUsers(string tenantId)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            return Ok(await _userRepository.GetWhere(user=>user.TenantId == Guid.Parse(tenantId)));
        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/{userId}")]
        public async Task<ActionResult<User>> GetUser(string tenantId, string userId)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (await _userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            return Ok(await _userRepository.GetById(Guid.Parse(userId)));
        }

        [EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("tenants/{tenantId}/users/emailValidation/{email}")]
        public async Task<ActionResult> PostEmailValidation(string tenantId,string email)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if(await _userRepository.FirstOrDefault(user=>user.Email == email) != null)
            {
                return BadRequest("Email id is not available");
            }
            else
            {
                return Ok("Email is available");
            }

        }

        [EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("tenants/{tenantId}/users/register")]
        public async Task<ActionResult> PostUser(string tenantId, [FromBody] UserDTO userDTO)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }

            if (ModelState.IsValid)
            {
                User userToBeAdded = await _userRepository.FirstOrDefault(user=>user.Email == userDTO.Email);
                if(userToBeAdded == null)
                {
                   await _userRepository.Add(new User {
                       Id = new Guid(),
                       Username = userDTO.Username,
                       Email = userDTO.Email,
                       Role = userDTO.UserRole,
                       Password = _encryptorDecryptor.Encrypt(userDTO.Password),
                       TenantId = Guid.Parse(tenantId)
                   });
                    return Ok("User added successfully");
                }
                else
                {
                    return Ok("User account already exists");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpGet]
        [Route("tenants/{tenantId}/users/userCountIsUnique")]
        public async Task<ActionResult<int>> GetUserCount(string tenantId,string userId)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (await _userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }

            return await _userRepository.CountWhere(user=>user.TenantId == Guid.Parse(tenantId));

        }


        [HttpPut]
        [Route("tenants/{tenantId}/users/{userId}")]
        public async Task<ActionResult> PutUser(string tenantId, string userId, [FromBody] UserDTO userDTO)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (await _userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            if (ModelState.IsValid)
            {
                User user = await _userRepository.GetById(Guid.Parse(userId));
                user.Email = userDTO.Email;
                user.Role = userDTO.UserRole;
                user.Password = _encryptorDecryptor.Encrypt(userDTO.Password);
                user.Email = userDTO.Email;
                user.Username = userDTO.Username;
                await _userRepository.Update(user);

                return Ok("user is updated");
            }
            else
            {
                return BadRequest("Please provide all the field of the user table");
            }

            
        }

        [HttpDelete]
        [Route("tenants/{tenantId}/users/{userId}")]
        public async Task<ActionResult> DeleteUser(string tenantId, string userId)
        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (await _userRepository.GetById(Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }
            User user =await _userRepository.GetById(Guid.Parse(userId));
            await _userRepository.Remove(user);
            return Ok("User contact deleted successfully");

        }


    }
}
