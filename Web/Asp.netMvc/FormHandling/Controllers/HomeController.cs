using FormHandling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormHandling.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FetchFormData(FormCollection collection)
        {
            ViewBag.Name = new List<string>()
            {
                collection[0],
                collection[0],
                collection[0],
                collection[0],
                collection[0],

            };
            return View();
        }

        public ActionResult FetchMultipleData(FormCollection collection)
        {
            ViewData["Id"] = collection[0];
            ViewData["Name"] = collection[1];
            return View();
        }

        public ActionResult Timer()
        {
            int hourOfDay = DateTime.Now.Hour;
            
            if(hourOfDay > 5 && hourOfDay <= 12)
            {
                ViewBag.Greet = "Good Morning";
            } else if(hourOfDay >= 12 && hourOfDay <= 18)
            {
                ViewBag.Greet = "Good Afternoon";
            }else if(hourOfDay >= 18 && hourOfDay <= 23)
            {
                ViewBag.Greet = "Good Evening";
            }
            else
            {
                ViewBag.Greet = "Good Night";
            }

            return View();
        }

        public ActionResult ModelDataFetching()
        {

           

            return View();

        }

        public ActionResult DynamicTextBox(FormCollection collection)
        {
            ViewData["userId"] = collection[0];
            ViewData["userName"] = collection[1];
            return View();
        }

        public ActionResult FormDataDropDown(FormCollection collection)
        {
            ViewData["dropdown_value"] = collection[0];
            return View();
        }
    }
}