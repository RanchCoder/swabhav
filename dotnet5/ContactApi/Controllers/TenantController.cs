using ContactApi.DTO;
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
    public class TenantController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public TenantController(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }


        [HttpGet]
        [Route("tenants/{tenantId}")]
        public Tenant GetTenantById(string tenantId)
        {
            return _contactRepository.GetTenantById(Guid.Parse(tenantId));
        }

        [HttpGet]
        [Route("tenants")]
        public IList<Tenant> GetTenants()
        {
            return _contactRepository.GetTenants().ToList();
        }

       




        [HttpPost]
        [Route("tenants")]
        public IActionResult AddTenant([FromBody] TenantDTO tenantDTO)
        {
            if (ModelState.IsValid)
            {
                bool isTenantAdded = _contactRepository.AddTenant(tenantDTO.TenantName);
                if (isTenantAdded)
                {
                    return Ok("tenant added successfully");
                }
                else
                {
                    return BadRequest("cannot add tenant");
                }
            }
            else
            {
                return BadRequest("Please check if all the field values are provided");
            }

        }
    }
}
