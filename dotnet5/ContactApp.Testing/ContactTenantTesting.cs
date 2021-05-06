using ContactApi.Controllers;
using ContactApi.DTO;
using ContactApp.Data.Repository;
using ContactApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ContactApp.Testing
{
    public class ContactTenantTesting
    {

        private readonly Mock<IAsyncContactRepository<Tenant>> _tenantRepository;
        private readonly Mock<IAsyncContactRepository<User>> _userRepository;
        private readonly Mock<IAsyncContactRepository<Contact>> _contactRepository;
        private readonly Mock<IAsyncContactRepository<Address>> _addressRepository;

        private readonly TenantController _tenantController;

        private List<Tenant> tenants = new List<Tenant>()
        {
            new Tenant{CompanyName = "Abc Corps", CompanyStrength = 1000, Id = new Guid()},
            new Tenant{CompanyName = "Cromwell Gutternburgs company", CompanyStrength = 500, Id = new Guid()},

            new Tenant{CompanyName = "Indraprasth Industries", CompanyStrength = 400, Id = new Guid()},
        };
        public ContactTenantTesting()
        {
            _tenantRepository = new  Mock<IAsyncContactRepository<Tenant>>();
            _userRepository = new Mock<IAsyncContactRepository<User>>();
            _contactRepository = new Mock<IAsyncContactRepository<Contact>>();
            _addressRepository = new Mock<IAsyncContactRepository<Address>>();
            _tenantController = new TenantController(_tenantRepository.Object,_userRepository.Object,_contactRepository.Object,_addressRepository.Object); 
        }

        

        [Fact]
        public async void GetTenants_ActionExecutes_ReturnsListOfTypeTenant()
        {
            _tenantRepository.Setup(tenantRepo =>tenantRepo.GetAll()).ReturnsAsync(tenants);
            var result =await _tenantController.GetTenants();
            var actionResult = Assert.IsType<ActionResult<List<Tenant>>>(result);
        }

        [Fact]
        public async void CompanyNameValidation_NullOrBlankValueForCompanyName_ReturnsBadRequestObject()
        {
            var result = await _tenantController.CompanyNameValidation("");
            Assert.IsType<BadRequestObjectResult>(result);

            var resultForBlankValue = await _tenantController.CompanyNameValidation(" ");
            Assert.IsType<BadRequestObjectResult>(resultForBlankValue);
        }


        [Fact]
        public async void AddTenant_OnModelError_ReturnsBadRequest()
        {
            _tenantController.ModelState.AddModelError("CompanyName","Company name is required");
            TenantDTO tenantToAdd = new TenantDTO { CompanyStrength = 1500 };
            var resultOnTenantAdd = await _tenantController.AddTenant(tenantToAdd);

            Assert.IsType<BadRequestObjectResult>(resultOnTenantAdd);

           
        }

        [Fact]
        public async void PutTenant_ModelError_ReturnsBadRequest()
        {
            _tenantController.ModelState.AddModelError("CompanyName", "Company name is required");
            TenantDTO tenantToPut = new TenantDTO { CompanyStrength = 1500 };
            var resultOnTenantUpdate = await _tenantController.PutTenant(new Guid().ToString(),tenantToPut);

            Assert.IsType<BadRequestObjectResult>(resultOnTenantUpdate);



        }

        [Fact]
        public async void PutTenant_NullIdPassed_ReturnsBadRequest()
        {
            TenantDTO tenantToPut = new TenantDTO {CompanyName = "MQU Corps" ,CompanyStrength = 1500 };
            var resultOnTenantUpdate = await _tenantController.PutTenant(null, tenantToPut);

            Assert.IsType<BadRequestObjectResult>(resultOnTenantUpdate);



        }


        [Fact]
        public async void DeleteTenant_NullIdPassed_ReturnsBadRequest()
        {
             var resultOnTenantDelete = await _tenantController.DeleteTenant(null);

            Assert.IsType<BadRequestObjectResult>(resultOnTenantDelete);



        }

    }
}
