using FirstCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplication.Services
{
    public class StudentService : IStudentService
    {
        private List<Student> _studentList = new List<Student>();
        private const bool OPERATION_SUCCESS = true, OPERATION_FAILURE = false;
        public bool AddStudent(Student student)
        {
            try
            {
                _studentList.Add(student);
               
                return OPERATION_SUCCESS;
            }catch(Exception ex)
            {
                return OPERATION_FAILURE;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = _studentList.Where(x => x.Id == id).FirstOrDefault();
                _studentList.Remove(studentToDelete);
                return OPERATION_SUCCESS;
            }
            catch (Exception ex)
            {
                return OPERATION_FAILURE;
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentList;
        }

        public bool UpdateStudent(Student student)
        {

            try
            {
                foreach (var stu in _studentList.Where(x => x.Id == student.Id))
                {
                    stu.Name = student.Name;
                    stu.Cgpa = student.Cgpa;
                    stu.Grade = student.Grade;
                   
                }
                return OPERATION_SUCCESS;
            }
            catch (Exception ex)
            {
                return OPERATION_FAILURE;
            }

        }

        
    }
}
