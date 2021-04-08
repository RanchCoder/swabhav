using FirstWebBasedDatabaseApp.Repository;
using FirstWebBasedDatabaseApp.Services;
using FirstWebBasedDatabaseApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebBasedDatabaseApp.Controllers
{
    public class HomeController : Controller
    {
        public static IContactRepository contactRepository = new ContactRepository(new ContactDBContext(),new ContactService());
        // GET: Home
        public ActionResult Index()
        {
           string result = contactRepository.AddContacts();
            if(result == "Success")
            {
                return View();
            }
            else
            {
                return View("Error");
            }
            
        }

        public ActionResult ViewContact()
        {
            ViewContactVM viewContact = new ViewContactVM(); 
                viewContact.Contacts = contactRepository.GetContacts();
            return View(viewContact);
        }


    }
}