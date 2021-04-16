using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactCore.Model;
using ContactCore.Services;
using ContactWebApi.ViewModel;

namespace ContactWebApi.Controllers
{
    public class HomeController : ApiController
    {
        protected static ContactService contactService = new ContactService();
        
        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            return Json(contactService.GetContacts());
        }

        [HttpGet]
        public IHttpActionResult GetContactById(int id)
        {
            return Json(contactService.GetContactById(id));
        }

        [HttpPost]
        public IHttpActionResult PostContacts(ContactVM contactVM)
        {
            if (ModelState.IsValid)
            {
               contactService.Add(new Contact()
                {
                    Id = contactVM.Id,
                    FirstName = contactVM.FirstName,
                    LastName = contactVM.LastName,
                    PhoneNo = contactVM.PhoneNo,
                    Address = contactVM.Address
                });

                return Ok("Contact added");

            }
            else
            {
                return BadRequest("All required fields are not present");
            }
        }


        [HttpPut]
        public IHttpActionResult PutContacts(ContactVM contactVM)
        {
            if (ModelState.IsValid)
            {
                bool isContactUpdated = contactService.Update(new Contact()
                {
                    Id = contactVM.Id,
                    FirstName = contactVM.FirstName,
                    LastName = contactVM.LastName,
                    PhoneNo = contactVM.PhoneNo,
                    Address = contactVM.Address
                });

                if (isContactUpdated)
                {
                    return Ok("Contact updated");
                }
                else
                {
                    return BadRequest("Cannot update contact");
                }

            }
            else
            {
                return BadRequest("All required fields are not present");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            bool isContactDeleted = contactService.Delete(id);
            if (isContactDeleted)
            {
                return Ok("Contact deleted successfully");
            }
            else
            {
                return BadRequest("Cannot delete contact");
            }
        }
    }
}
