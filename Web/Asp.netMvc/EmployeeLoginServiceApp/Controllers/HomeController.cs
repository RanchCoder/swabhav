using EmployeeLoginServiceApp.Services;
using EmployeeLoginServiceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeLoginServiceApp.Controllers
{
    public class HomeController : Controller
    {
        public EmployeeService employeeService = new EmployeeService();
        public ActionResult Index()
        {
            if(Session["AuthenticUser"] == null)
            {

                return View("Login");
            }
            else
            {
                EmployeeVM employeeData = (EmployeeVM)Session["AuthenticUser"]; 
                return View(employeeData);

            }
        }

        public ActionResult InitializeContent()
        {
           bool recordAdded =  employeeService.InitializeTables();
            if (recordAdded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AuthenticateUser(UserCredentialVM userCredential)
        {
            bool isAuthenticAccount = employeeService.IsAuthenticUser(userCredential.UserName,userCredential.Password);
            if (isAuthenticAccount)
            {
                var employeeData = employeeService.GetEmployeeData(userCredential.UserName, userCredential.Password);
                EmployeeVM employee = new EmployeeVM() {
                    Id = employeeData.Id,
                    FirstName = employeeData.FirstName,
                    LastName = employeeData.LastName,
                    Salary  = employeeData.Salary,
                    Department = employeeData.Department,
                    Designation = employeeData.Designation,

                };

                Session["AuthenticUser"] = employee;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}