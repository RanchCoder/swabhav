using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index(string name)
        {
            ViewBag.Names = new List<string>()
           {
               name,
               name,
               name,
               name,
               name
           };
            return View();
        }

        public ActionResult Hello()
        {
            return View();
        }

        
    }
}