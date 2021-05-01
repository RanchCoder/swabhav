using ContactApi.DTO;
using ContactApp.Data.Repository;
using ContactApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly IAsyncContactRepository<Tenant> _tenantRepository;
        private readonly IAsyncContactRepository<User> _userRepository;
        private readonly IAsyncContactRepository<Contact> _contactRepository;
        private readonly IAsyncContactRepository<Address> _addressRepository;

        public TenantController(IAsyncContactRepository<Tenant> asyncTenantRepository,
            IAsyncContactRepository<User> asyncUserRepository,
            IAsyncContactRepository<Contact> asyncContactRepository,
            IAsyncContactRepository<Address> asyncAddressRepository)
        {
            this._tenantRepository = asyncTenantRepository;
            this._userRepository = asyncUserRepository;
            this._contactRepository = asyncContactRepository;
            this._addressRepository = asyncAddressRepository;
        }


        [HttpPost]




        [HttpGet]
        [Route("tenants/{tenantId}")]
        public async Task<ActionResult<Tenant>> GetTenantById(string tenantId)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            return Ok(await _tenantRepository.GetById(Guid.Parse(tenantId)));
        }

        [HttpGet]
        [Route("tenants/{tenantId}/countData")]
        public async Task<ActionResult<CountDTO>> GetCountDetails(string tenantId)
        {


            if (tenantId != null)
            {
                var usersCount = await _userRepository.CountWhere(user=>user.TenantId == Guid.Parse(tenantId));
                var contactCount = await _contactRepository.CountWhere(contact=>contact.User.TenantId == Guid.Parse(tenantId));
                var addressCount = await _addressRepository.CountWhere(address=>address.Contact.User.TenantId == Guid.Parse(tenantId));
                var tenantRecord = await _tenantRepository.GetById(Guid.Parse(tenantId));

                var employeeCount = tenantRecord.CompanyStrength;

                return Ok(new CountDTO { UserCount = usersCount, ContactCount = contactCount, AddressCount = addressCount, CompanyStrength = employeeCount });
            }
            else
            {
                return BadRequest("Cannot fetch data");
            }

        }



        [HttpGet]
        [Route("tenants/companyIsUnique/{companyName}")]
        public async Task<ActionResult<int>> GetCompanyName(string companyName)

        {
            if (companyName != null)
            {
                return Ok(await _tenantRepository.CountWhere(tenant=>tenant.CompanyName == companyName));
            }
            else
            {
                return BadRequest("please provide company name");
            }

        }

        [HttpGet]
        [Route("tenants/companyTenantIsUnique/{companyName}")]
        public async Task<ActionResult<TokenDTO>> GetTenantIdByCompanyName(string companyName)

        {
            if (companyName != null)
            {
                var tenant = await _tenantRepository.FirstOrDefault(tenant=>tenant.CompanyName == companyName);
                if (tenant == null)
                {
                    return BadRequest("cannot fetch tenant id");
                }
                
                return Ok(new TokenDTO { Token = tenant.Id, CompanyName = tenant.CompanyName });
            }
            else
            {
                return BadRequest("please provide company name");
            }

        }

        [HttpGet]
        [Route("tenants/companyEmailIsUnique/{email}")]
        public async Task<ActionResult<int>> GetCountForEmailProvided(string email)

        {
            if (email != null)
            {
                return await _userRepository.CountWhere(user=>user.Email == email);
               
            }
            else
            {
                return BadRequest("please provide a valid email");
            }

        }


        [HttpGet]
        [Route("tenants")]
        public async Task<ActionResult<List<Tenant>>> GetTenants()
        {
            return Ok(await _tenantRepository.GetAll());
        }


        [HttpPost]
        [Route("tenants/companyNameIsUnique/{companyName}")]
        public async Task<ActionResult> CompanyNameValidation(string companyName)
        {
            if(companyName != null)
            {
                if(await _tenantRepository.FirstOrDefault(tenant=>tenant.CompanyName == companyName) == null)
                {
                    return Ok("Company name is available");
                }
                else
                {
                    return BadRequest("Company name is not available");
                }
            }
            else
            {
                return BadRequest("company name is invalid");
            }
        }


        [HttpPost]
        [Route("tenants")]
        public async Task<ActionResult> AddTenant([FromBody] TenantDTO tenantDTO)
        {
            if (ModelState.IsValid)
            {
                await _tenantRepository.Add(new Tenant { CompanyName = tenantDTO.CompanyName, CompanyStrength = tenantDTO.CompanyStrength });
                return Ok("Tenant added successfully");
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }

        [HttpPut]
        [Route("tenants/{tenantId}")]
        public async Task<ActionResult> PutTenant(string tenantId, [FromBody] TenantDTO tenantDTO)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }

            if (ModelState.IsValid)
            {
                Tenant tenantToUpdate =await _tenantRepository.FirstOrDefault(tenant=>tenant.Id == Guid.Parse(tenantId));
                tenantToUpdate.CompanyName = tenantDTO.CompanyName;
                tenantToUpdate.CompanyStrength = tenantDTO.CompanyStrength;
                await _tenantRepository.Update(tenantToUpdate);
                return Ok("Tenant Updated successfully");
            }
            else
            {
                return BadRequest("Please provide all fields");
            }

        }

        [HttpDelete]
        [Route("tenants/{tenantId}")]
        public async Task<ActionResult> DeleteTenant(string tenantId)
        {
            if (_tenantRepository.GetById(Guid.Parse(tenantId)) == null)
            {
                return BadRequest("Tenant id is not valid");
            }
            Tenant tenantToDelete = await _tenantRepository.FirstOrDefault(tenant => tenant.Id == Guid.Parse(tenantId));
            await _tenantRepository.Remove(tenantToDelete);
            return Ok("Tenant deleted Successfully");

        }
    }
}
