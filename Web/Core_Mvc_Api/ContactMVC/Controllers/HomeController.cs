using ContactWebApi.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ContactMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewContacts()
        {
            IEnumerable<ContactVM> contacts;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44375/api/");
                var responseTask = client.GetAsync("home");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    contacts = JsonConvert.DeserializeObject<List<ContactVM>>(readTask);
                }
                else
                {
                    contacts = new List<ContactVM>();
                    ModelState.AddModelError(string.Empty,"Server error, please contact administrator");
                }

                return View(contacts);


            }
        }
    }
}