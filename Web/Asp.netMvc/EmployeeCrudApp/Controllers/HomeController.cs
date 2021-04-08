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
                return View("ShowAllEmployee");
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
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    Designation = employee.Designation
                });

                return RedirectToAction("ShowAllEmployee",new { Message = "Record Added Successfully"});
            }
            else
            {
                return RedirectToAction("ShowAllEmployee", new { Message = "Record Not Added Successfully" });
            }

            
        }

        public ActionResult ShowAllEmployee(string message)
        {
            if(message != null)
            {
                ViewBag.Message = message;
            }
            EmployeeVM employees = new EmployeeVM(); 
                employees.Employees = employeeService.GetEmployeeData();
            return View(employees);

        }

        public ActionResult EditEmployeeVM(int id)
        {
            EditEmployeeVM employee = new EditEmployeeVM();

             var employeeDataFromId =  employeeService.GetEmployeeById(id);
            employee.Id = employeeDataFromId.Id;
            employee.Name = employeeDataFromId.Name;
            employee.Designation = employeeDataFromId.Designation;
            employee.Department = employeeDataFromId.Department;
            employee.Salary = employeeDataFromId.Salary;
            return View(employee);
        }

        public ActionResult SaveEmployeeData(EditEmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
               employeeService.EditEmployeeData(new Employee()
                {
                   Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Designation = employee.Designation,
                    Salary = employee.Salary
                });                
                return RedirectToAction("ShowAllEmployee",new { Message="Record updated successfully."});
                              
            }
            else
            {
                return  RedirectToAction("ShowAllEmployee", new { Message = "Cannot update record." });
            }
            
        }

        public ActionResult DeleteEmployeeVM(int id)
        {
            string result = employeeService.DeleteEmployee(id);
            if(result == "SUCCESS")
            {
                return RedirectToAction("ShowAllEmployee", new { Message = "Employee record deleted successfully." });
            }
            else
            {
                return RedirectToAction("ShowAllEmployee",new { Message="Unable to delete Employee record successfully."});

            }
        }



    }
}