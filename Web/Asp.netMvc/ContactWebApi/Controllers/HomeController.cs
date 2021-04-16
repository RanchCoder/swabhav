using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactCore.Service;
using ContactCore.Model;

using System.Web.Http.Description;
using ContactWebApi.ViewModels;

namespace ContactWebApi.Controllers
{
   
    public class HomeController : ApiController
    {
        ContactService contactService = new ContactService();

       
       
        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            contactService.InitializeList();
            return Json(contactService.GetContacts());
        }

        [HttpGet]
        public IHttpActionResult GetContactById(int id)
        {
            return Json(contactService.GetContactById(id));
        }

        [HttpPost]
        public IHttpActionResult PostContacts(ContactVM contactViewModel)
        {
            if (ModelState.IsValid)
            {
                
                contactService.AddContact(new Contact() { 
                    Id = contactViewModel.Id,
                    FirstName = contactViewModel.FirstName,
                    LastName = contactViewModel.LastName,
                    PhoneNo = contactViewModel.PhoneNo,
                    Address = contactViewModel.Address
                });
                return Ok("Contact added");
            }
            else
            {
                return BadRequest("Request cannot be serviced");
            }
           
        }

       
       [HttpPut]
        public IHttpActionResult PutContact(ContactVM contactVM)
        {
            if (ModelState.IsValid)
            {
                contactService.EditContact(new Contact (){ 
                    Id=contactVM.Id,
                    FirstName = contactVM.FirstName,
                    LastName = contactVM.LastName,
                    Address = contactVM.Address,
                    PhoneNo = contactVM.PhoneNo,
                });
                return Ok("Contact edited");
            }
            else
            {
                return BadRequest("Request cannot be serviced");
            }

        }

       [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            bool isContactDeleted = contactService.DeleteContact(id);
            if (isContactDeleted)
            {
                return Ok("contact deleted successfully");
            }
            else
            {
                return BadRequest("Cannot delete contact");
            }


        }
    }
}
