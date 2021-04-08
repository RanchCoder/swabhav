using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactAddressMVCApp.DBContext;
using ContactAddressMVCApp.Services;
using ContactAddressMVCApp.ViewModels;

namespace ContactAddressMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactAddressService contactAddressService;
        public HomeController()
        {
             this.contactAddressService = new ContactAddressService(new ContactAddressDBContext());

        }
        // GET: Home
        public ActionResult Index(string Message)
        {           
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            return View();
        }

        public ActionResult ViewContacts(string Message)
        {
            if (Message != null)
            {
                ViewBag.Message = Message;
            }

            var contactList = contactAddressService.GetContacts();
            List<ViewContactsVM> contacts = new List<ViewContactsVM>();
            foreach(var contact in contactList)
            {
                contacts.Add(new ViewContactsVM() { Id=contact.Id,FirstName = contact.FirstName,LastName=contact.LastName,PhoneNo=contact.PhoneNo });

            }
            return View(contacts);
        }

        public ActionResult ShowAddresses(int id,string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            var contact = contactAddressService.GetContactById(id);
            var addressList = contactAddressService.GetAddress(contact);
            List<ViewAllAddressesVM> addressListForView = new List<ViewAllAddressesVM>();
            foreach(var address in addressList)
            {
                addressListForView.Add(new ViewAllAddressesVM() { Id = address.Id,Location = address.Location,ContactId = address.Contact.Id});
            }
            return View(addressListForView);

        }

        public ActionResult EditAddress(int addressId, int contactId)
        {
            var addressFromId = contactAddressService.GetAddressById(addressId);
            EditAddressVM editAddressVM = new EditAddressVM() { Id = addressId,Location=addressFromId.Location , IdOfContact = contactId};

            return View(editAddressVM);
        }

        public ActionResult SaveEditedAddress(EditAddressVM editedAddress)
        {
            
            bool isAddressEdited = contactAddressService.EditAddress(editedAddress.IdOfContact,editedAddress.Id,editedAddress.Location);
            if (isAddressEdited)
            {
                return RedirectToAction("ViewContacts",new {Message = "address edited successfully"});
            }
            else
            {
                return RedirectToAction("ViewContacts", new {Message = "failed to edit address" });
            }
        }

        public ActionResult AddContact(string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            return View();
        }

        public ActionResult SaveNewContact(AddContactVM contact)
        {
            if (ModelState.IsValid)
            {
                contactAddressService.AddContact(new Models.Contact() { FirstName = contact.FirstName,LastName=contact.LastName,PhoneNo=contact.PhoneNo });
                return RedirectToAction("Index",new { Message="Contact Added Successfully" });
            }
            else
            {
                return RedirectToAction("AddContact", new { Message = "Cannot Add Contact, try again." });
            }
        }

        public ActionResult DeleteContact(int id)
        {
          bool isContactDeleted =  contactAddressService.DeleteContact(id);
            if (isContactDeleted)
            {
               return RedirectToAction("ViewContacts", new { Message = "Contact Deleted Successfully" });
            }
            else
            {
                return RedirectToAction("ViewContacts", new { Message = "Cannot Delete Contact" });

            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}