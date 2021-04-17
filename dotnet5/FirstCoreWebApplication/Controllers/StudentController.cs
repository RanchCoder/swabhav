using FirstCoreWebApplication.Models;
using FirstCoreWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentService.GetStudents();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            bool isContactAdded = studentService.AddStudent(student);
            if (isContactAdded)
            {
                return new ObjectResult("student added");
            }
            return BadRequest("cannot add student");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            bool isContactUpdated = studentService.UpdateStudent(student);
            if (isContactUpdated)
            {
                return new ObjectResult("student updated");
            }
            return BadRequest("student add updated");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            bool isStudentDeleted = studentService.DeleteStudent(id);
            if (isStudentDeleted)
            {
                return new ObjectResult("Student deleted");
            }
            return BadRequest("cannot delete student");
        }

    }
}
