using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ContactCore.Model;
using ContactWebApi.Controllers;

namespace ContactMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            List<Contact> contactInfo;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/v1/Contact");
                //HTTP GET
                var responseTask = client.GetAsync("get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Contact>>();
                   
                    readTask.Wait();

                    contactInfo = readTask.Result;
                }
                else  
                {
                    
                    contactInfo = new List<Contact>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

                return View();
        }
    }
}