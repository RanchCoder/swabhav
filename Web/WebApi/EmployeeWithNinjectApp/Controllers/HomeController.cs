using EmployeeWithNinjectApp.DTO;
using EmployeeWithNinjectApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace EmployeeWithNinjectApp.Controllers
{
    [RoutePrefix("api/v1/Employee")]
    public class HomeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _employeeService.InitializeList();
        }

        [Route("get")]
        public IHttpActionResult GetEmployees()
        {
            return Json(_employeeService.GetEmployees());
        }


        [Route("post")]
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult PostEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            bool isEmployeeAdded = _employeeService.AddEmployee(employeeDTO);
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
            bool isEmployeeUpdated = _employeeService.UpdateEmployee(employeeDTO);
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
        public IHttpActionResult DeleteEmployee([FromBody]int id)
        {
            //bool isEmployeeDeleted = _employeeService.DeleteEmployee(deleteEmployeeDTO);
            //if (isEmployeeDeleted)
            //{
            //    return Ok("Employee deleted successfully");
            //}
            //else
            //{
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict));
            //}

            return Ok(id);


        }

        [Route("deleteEmployee")]

        [ResponseType(typeof(int))]
        public IHttpActionResult Delete(int id)
        {

            bool isEmployeeDeleted = _employeeService.DeleteEmployee(id);
            if (isEmployeeDeleted)
            {
                return Ok("Employee deleted");
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict));

            }
        }

    }
}
