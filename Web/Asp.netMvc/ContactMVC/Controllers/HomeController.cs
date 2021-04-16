using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using ContactMVC.ViewModels;
using Newtonsoft.Json;

namespace ContactMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IList<ContactViewModel> contacts = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://vishal-contact-list.azurewebsites.net/api/");
                var responseTalk = client.GetAsync("home");
                responseTalk.Wait();

                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    contacts = JsonConvert.DeserializeObject<IList<ContactViewModel>>(readTask);

                   
                }
                else  
                {


                    contacts =new List<ContactViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }

            return View(contacts);
        }

        public ActionResult PostContact()
        {
            return View();

        }

        public ActionResult SavePostContact(ContactViewModel contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vishal-contact-list.azurewebsites.net/api/");

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
                client.BaseAddress = new Uri("http://vishal-contact-list.azurewebsites.net/api/");
                var response = client.GetAsync("home?id="+id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<ContactViewModel>(readTask);
                   
                  


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
                client.BaseAddress = new Uri("http://vishal-contact-list.azurewebsites.net/api/");
                var putTask = client.PutAsJsonAsync<ContactViewModel>("home",contactViewModel);
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
                client.BaseAddress = new Uri("http://vishal-contact-list.azurewebsites.net/api/");
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