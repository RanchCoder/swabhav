using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Domain.Models;
using ContactApp.Data.Repository;
using ContactApi.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ContactApi.Token;

namespace ContactApi.Controllers
{
    [Route("api/v1/tenants")]
    [ApiController]
    public class AuthenticationAuthorizationController : ControllerBase
    {
        private readonly IAsyncContactRepository<Tenant> _tenantRepository;
        private readonly IAsyncContactRepository<User> _userRepository;
        private readonly IAsyncContactRepository<SuperAdmin> _superAdmin;
        private EncryptorDecryptor _encryptorDecryptor;
        
        private ICustomTokenManager _customTokenManager;
        public AuthenticationAuthorizationController(ICustomTokenManager customTokenManager, EncryptorDecryptor encryptorDecryptor,IAsyncContactRepository<SuperAdmin> superAdmin,IAsyncContactRepository<Tenant> tenantRepository,IAsyncContactRepository<User> userRepository)
        {
            _customTokenManager = customTokenManager;
            _encryptorDecryptor = encryptorDecryptor;
            _superAdmin = superAdmin;
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
        }

        [Route("user/login")]
        [HttpPost]
        public async Task<ActionResult> PostLoginUser([FromBody] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                
                var userAccount = await _userRepository.FirstOrDefault(user=>user.Username == userDTO.Username && user.Password == _encryptorDecryptor.Encrypt(userDTO.Password));
                if (userAccount == null)
                {
                    return BadRequest("User account does not exist");
                }

                return Ok(userAccount);
            }
            else
            {
                return BadRequest("Please make sure credentials are correct");
            }

        }

        [Route("user/registration")]
        [HttpPost]
        public async Task<ActionResult> PostRegisterUser([FromBody] RegistrationDTO registrationDTO)
        {
            await _tenantRepository.Add(new Tenant() { CompanyName = registrationDTO.CompanyName, CompanyStrength = registrationDTO.CompanyStrength });
            
            if(await _tenantRepository.FirstOrDefault(tenant=>tenant.CompanyName == registrationDTO.CompanyName) != null)
            {
                Tenant tenantAcc = await _tenantRepository.FirstOrDefault(tenant=>tenant.CompanyName == registrationDTO.CompanyName);

                await _userRepository.Add(new User()
                {
                    Id = new Guid(),
                    Username = registrationDTO.Username,
                    Password = _encryptorDecryptor.Encrypt(registrationDTO.Password),
                    Email = registrationDTO.CompanyEmail,
                    Role = "Admin",
                    TenantId = tenantAcc.Id,
                }) ;
                
                if(await _userRepository.FirstOrDefault(user=>user.Email == registrationDTO.CompanyEmail) != null)
                {
                    return Ok("User added successfully");
                }
                else{
                    return BadRequest("Cannot add user");
                }
            }
            else
            {
                return BadRequest("Cannot Register User");
            }
        }

        [Route("superAdminLogin")]
        [HttpPost]
        public async Task<ActionResult> PostLoginSuperAdmin([FromBody] SuperAdminLoginDTO superAdminLoginDTO)
        {
            if (ModelState.IsValid)
            {
                SuperAdmin userData = await _superAdmin.FirstOrDefault(user => user.Email == superAdminLoginDTO.Email && user.Password == superAdminLoginDTO.Password);
                if (userData != null)
                {
                    string token = _customTokenManager.CreateSuperAdminToken(userData);
                    return Ok(new { Token = token });
                }
                else
                {
                    
                    return BadRequest("SuperAdmin credentials not valid");
                }
            }
            else
            {
                return BadRequest("Please provide value for all fields");
            }
        }

        [Route("{tenantId}/user/login")]
        [HttpPost]
        public async Task<ActionResult> PostLoginUser(string tenantId, [FromBody] LoginDTO loginDTO)
        {
            Tenant tenant =await _tenantRepository.GetById(Guid.Parse(tenantId));
            if (tenant == null)
            {
                return BadRequest("Tenant id is not valid");
            }

            if (ModelState.IsValid)
            {
                User userData = await _userRepository.FirstOrDefault(user => user.TenantId == Guid.Parse(tenantId) && user.Email == loginDTO.Email && user.Password == _encryptorDecryptor.Encrypt(loginDTO.Password));

                if (userData != null)
                {                   
                    string token = _customTokenManager.CreateToken(userData);
                    return Ok(new { Token = token });

                }
                else
                {
                    return BadRequest("credentials provided dot not match to any existing account");
                }
            }
            else
            {
                return BadRequest("Cannot Login the user, try again");
            }

        }

        [HttpGet]
        [Route("{tenantId}/user")]
        public async Task<ActionResult<TokenDTO>> GetTenantIdByCompanyName(string companyName)

        {

            if (companyName != null)
            {
                Tenant tenant = await _tenantRepository.FirstOrDefault(tenant=>tenant.CompanyName == companyName);
               
                if (tenant == null)
                {
                    return BadRequest("cannot fetch tenant id");
                }
                
                return Ok(new TokenDTO { Token = tenant.Id });
            }
            else
            {
                return BadRequest("please provide company name");
            }

        }

        [HttpGet]
        [Route("{tenantId}/userNameAndRole/{userId}")]
        public async Task<ActionResult<UserRoleDTO>> GetUserRole(string tenantId, string userId)

        {
            if (await _tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            if (await _userRepository.FirstOrDefault(user => user.Id == Guid.Parse(userId)) == null)
            {
                return BadRequest("User id is not valid");
            }

           
                User user = await _userRepository.FirstOrDefault(user=>user.TenantId == Guid.Parse(tenantId) && user.Id == Guid.Parse(userId));
                if (user == null)
                {
                    return BadRequest("cannot find user role");
                }
                
                return Ok(new UserRoleDTO { UserRole = user.Role, UserName = user.Username });
           
        }
    }



}
