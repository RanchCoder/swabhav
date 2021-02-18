using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_App.model
{
    class Student : IComparable
    {
        private string firstNameOfStudent;
        private string lastNameOfStudent;
        private string cityOfStudent;
        private string residentLocationOfStudent;
        private string stateOfStudent;
        private string streamOfStudent;
        private int rollNumberOfStudent;
        private string subStream;
        private string divisionOfStudent;
        List<string> courseSelectedByStudent;

        public Student(string firstNameOfStudent, 
                       string lastNameOfStudent,
                       string residentLocationOfStudent,
                       string cityOfStudent,
                       string stateOfStudent,
                       string streamOfStudent,
                       int rollNumberOfStudent,
                       string subStream,
                       string divisionOfStudent,
                       List<string> courseSelectedByStudent
            )
        {
            this.firstNameOfStudent = firstNameOfStudent;
            this.lastNameOfStudent = lastNameOfStudent;
            this.residentLocationOfStudent = residentLocationOfStudent;
            this.cityOfStudent = cityOfStudent;
            this.stateOfStudent = stateOfStudent;
            this.streamOfStudent = streamOfStudent;
            this.rollNumberOfStudent = rollNumberOfStudent;
            this.subStream = subStream;
            this.divisionOfStudent = divisionOfStudent;
            this.courseSelectedByStudent = courseSelectedByStudent;
        }

        public string FirstNameOfStudent { get => firstNameOfStudent; set => firstNameOfStudent = value; }
        public string LastNameOfStudent { get => lastNameOfStudent; set => lastNameOfStudent = value; }
        public string CityOfStudent { get => cityOfStudent; set => cityOfStudent = value; }
        public string ResidentLocationOfStudent { get => residentLocationOfStudent; set => residentLocationOfStudent = value; }
        public string StateOfStudent { get => stateOfStudent; set => stateOfStudent = value; }
        public string StreamOfStudent { get => streamOfStudent; set => streamOfStudent = value; }
        public int RollNumberOfStudent { get => rollNumberOfStudent; set => rollNumberOfStudent = value; }
        public string SubStream { get => subStream; set => subStream = value; }
        public string DivisionOfStudent { get => divisionOfStudent; set => divisionOfStudent = value; }

        public int CompareTo(object obj)
        {
            Student objTobeCompared = (Student)obj;
            return rollNumberOfStudent.CompareTo(objTobeCompared.RollNumberOfStudent);
        }
    }
}
