using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_App.model
{
    class College
    {
        private CollegeSpecification collegeSpecification;
        private SortedSet<Student> studentsList;
        public College(CollegeSpecification specificationForCollege,SortedSet<Student> listOfStudentsInCollege)
        {
            this.collegeSpecification = specificationForCollege;
            this.studentsList = listOfStudentsInCollege;
        }

        internal CollegeSpecification CollegeSpecification { get => collegeSpecification; }
        internal SortedSet<Student> StudentsList { get => studentsList; set => studentsList = value; }
    }
}
