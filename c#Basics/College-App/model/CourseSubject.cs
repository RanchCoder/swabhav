using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_App.model
{
    class CourseSubject
    {
        private EnumsForCollegeApp.SubjectNameAndCode courseName;
        private string courseCode;

        public CourseSubject(EnumsForCollegeApp.SubjectNameAndCode courseName)
        {
            this.courseName = courseName;
        }
        public EnumsForCollegeApp.SubjectNameAndCode CourseName { get => courseName; set => courseName = value; }
        public string CourseCode { get => courseCode; set => courseCode = value; }
    }
}
