using FirstWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApiApp.Services;

namespace FirstWebApiApp.Controllers
{
    [RoutePrefix("api/employee/v1")]
    public class HomeController : ApiController
    {

        EmployeeService employeeService = EmployeeService.GetEmployeeService();
        
        public HomeController()
        {
           
        }
        
        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetAnything()
        {
            employeeService.InitializeEmployeeList();
            return Json(employeeService.GetEmployeeList());
             
        }



        [HttpPost]
        [System.Web.Http.Description.ResponseType(typeof(Employee))]
        public  IHttpActionResult PostAnything([FromBody] Employee employee)
        {
             employeeService.GetEmployeeList().Add(employee);
             return Ok("Employee Record saved");
        }

        [HttpPut]

        public IHttpActionResult PutAnything([FromBody] Employee employee)
        {
            foreach(var emp in employeeService.GetEmployeeList().Where(e=>e.Id == employee.Id))
            {
                emp.Name = employee.Name;
                emp.DepartmentName = employee.DepartmentName;
                emp.Designation = employee.Designation;
                emp.Salary = employee.Salary;

            }

            return Ok("Updated the employee Record");
        }

        [HttpDelete]
        
        public IHttpActionResult DeleteAnything(int id)
        {
            var employeeToRemove = employeeService.GetEmployeeList().Where(x=>x.Id == id).FirstOrDefault();
            employeeService.GetEmployeeList().Remove(employeeToRemove);
            return Ok("Employee Record deleted");
        }
    }
}
