using EmployeeCrudApp.Models;
using EmployeeCrudApp.Service;
using EmployeeCrudApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCrudApp.Controllers
{
    public class HomeController : Controller
    {
        public static EmployeeService employeeService = new EmployeeService();
        // GET: Home
        public ActionResult Index(string message)
        {
            if(message != null)
            {
                ViewBag.Message = message;
                ViewBag.ShowAllEmployee = true;
            }
            return View();
        }

        public ActionResult AddEmployeeData(Employee employee)
        {
            int result = employeeService.AddEmployee(employee);
            if (result > 0)
            {
                EmployeeVM employees = new EmployeeVM();

                employees.Employees = employeeService.GetEmployeeData();
                return View(employees);
            }
            else
            {
                return RedirectToAction("Index",new { Message="cannot add the record"});
            }
        }

        public ActionResult ShowAddForm(string message)
        {
            if(message != null)
            {
                ViewBag.Message = message;

            }
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployeeVM(EmployeeAddVM employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.AddEmployee(new Employee()
                {
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    Designation = employee.Designation
                });

                return RedirectToAction("ShowAddForm",new { Message = "Record Added Successfully"});
            }
            else
            {
                return RedirectToAction("ShowAddForm", new { Message = "Record Not Added Successfully" });
            }

            
        }

        public ActionResult EditEmployeeData()
        {
            return View();
        }

       
    }
}