using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Contact_MVC.ViewModels;
using Newtonsoft.Json;

namespace Contact_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<ContactViewModel> contacts;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vishal-contactlist-api-db.azurewebsites.net/api/");
                var responseTask = client.GetAsync("home");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    contacts = JsonConvert.DeserializeObject<List<ContactViewModel>>(readTask);
                }
                else
                {
                    contacts = new List<ContactViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error, please contact administrator");
                }

                return View(contacts);
                return View();
            }

           


        }

        public ActionResult AddContact()
        {
            return View();
        }

        public ActionResult SaveNewContact(ContactViewModel contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vishal-contactlist-api-db.azurewebsites.net/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ContactViewModel>("home", contact);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("PostContact");

        }

       


       

        public ActionResult EditContact(int id)
        {
            ContactViewModel contact = new ContactViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vishal-contactlist-api-db.azurewebsites.net/api/");
                var response = client.GetAsync("home?id=" + id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                   var objresult = JsonConvert.DeserializeObject<ContactViewModel>(readTask);
                    contact = objresult; 
                    

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                return View(contact);
            }
        }

        public ActionResult SaveEditedContact(ContactViewModel contactViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vishal-contactlist-api-db.azurewebsites.net/api/");
                var putTask = client.PutAsJsonAsync<ContactViewModel>("home", contactViewModel);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("PostContact");
        }

        public ActionResult DeleteContact(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vishal-contactlist-api-db.azurewebsites.net/api/");
                var deleteTask = client.DeleteAsync("home/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("Index");

        }

    }
}