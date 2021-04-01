using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidateAndAuthenticateApp.Models;

namespace ValidateAndAuthenticateApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string err)
        {
            if(err != null)
            {
                ViewBag.ErrorContent = err;
            }
            return View();
        }

        [HttpPost]
        public ActionResult FormInputAuthentication(User user)
        {
                if(user.UserName == "vishal" && user.Password == "abcd1234")
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index",new { err="user has entered wrong data"});
            }
                
            
           
        }

    }
}