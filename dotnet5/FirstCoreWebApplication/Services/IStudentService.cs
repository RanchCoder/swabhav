using FirstCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplication.Services
{
    public interface IStudentService
    {
         bool AddStudent(Student student);
         bool UpdateStudent(Student student);
         bool DeleteStudent(int id);
        IEnumerable<Student> GetStudents();
    }
}
