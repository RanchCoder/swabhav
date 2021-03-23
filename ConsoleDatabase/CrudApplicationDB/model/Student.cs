using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApplicationDB.model
{
    class Student
    {
        private int _idOfStudent;
        private string _nameOfStudent;
        private int _marksOfStudent;

        public Student(int idOfStudent, string nameOfStudent, int marksOfStudent)
        {
            _idOfStudent = idOfStudent;
            _nameOfStudent = nameOfStudent;
            _marksOfStudent = marksOfStudent;
        }

        public int IdOfStudent { get => _idOfStudent; set => _idOfStudent = value; }
        public string NameOfStudent { get => _nameOfStudent; set => _nameOfStudent = value; }
        public int MarksOfStudent { get => _marksOfStudent; set => _marksOfStudent = value; }
    }
}
