using LoginWithServiceApp.Models;
using LoginWithServiceApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginWithServiceApp.Controllers
{
    public class HomeController : Controller
    {
        public UserService userService = new UserService();
        // GET: Home
        public ActionResult Index(string ErrorMessage)
        {
            if(ErrorMessage != null)
            {
                ViewBag.ErrorMessage = ErrorMessage;
            }
            return View();
        }

        public ActionResult ValidateUserData(User user)
        {
            bool result = userService.IsValidUser(user);
            if (result)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index",new { ErrorMessage = "Please enter correct credentials to login successfully"});
            }
        }
    }
}