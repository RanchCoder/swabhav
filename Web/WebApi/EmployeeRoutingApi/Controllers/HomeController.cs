using EmployeeRoutingApi.DTO;
using EmployeeRoutingApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeRoutingApi.Models;

namespace EmployeeRoutingApi.Controllers
{
    [RoutePrefix("api/v1/Employee")]
    public class HomeController : ApiController
    {
        public EmployeeService employeeService = EmployeeService.GetEmployeeService();

        public HomeController()
        {
            employeeService.IntializeList();
        }

        [Route("get")]
        public IHttpActionResult GetEmployees()
        {
            return Json(employeeService.Employees);
        }


        [Route("post")]
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult PostEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            bool isEmployeeAdded = employeeService.AddEmployee(employeeDTO);
            if (isEmployeeAdded)
            {
                return Ok("Employee added successfully");

            }
            else
            {
                
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict));
            }
        }

        [Route("put")]
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult PutEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            bool isEmployeeUpdated = employeeService.UpdateEmployee(employeeDTO);
            if (isEmployeeUpdated)
            {
                return Ok("Employee updated successfully");

            }
            else
            {

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict));
            }
        }

        [Route("delete")]
        [ResponseType(typeof(DeleteEmployeeDTO))]
        public IHttpActionResult DeleteEmployee(DeleteEmployeeDTO deleteEmployeeDTO)
        {
            bool isEmployeeDeleted = employeeService.DeleteEmployee(deleteEmployeeDTO);
            if (isEmployeeDeleted)
            {
                return Ok("Employee deleted successfully");
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict));
            }

           
        }
    }
}
