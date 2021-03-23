using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Employee
    {
        private int _id;
        private string _name;
        private int _salary;
        private string _designation;

        public Employee(int id, string name, int salary, string designation)
        {
            _id = id;
            _name = name;
            _salary = salary;
            _designation = designation;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Salary { get => _salary; set => _salary = value; }
        public string Designation { get => _designation; set => _designation = value; }
    }
}
