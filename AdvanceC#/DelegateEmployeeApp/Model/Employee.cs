using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DelegateEmployeeApp.Model
{

    public delegate bool IsPromotable(Employee employee);
    public class Employee
    {
        private string _nameOfEmployee;
        private int _idOfEmployee;
        private double _salaryOfEmployee;
        private int _experienceOfEmployee;

        public Employee(string nameOfEmployee, int idOfEmployee, double salaryOfEmployee, int experienceOfEmployee)
        {
            _nameOfEmployee = nameOfEmployee;
            _idOfEmployee = idOfEmployee;
            _salaryOfEmployee = salaryOfEmployee;
            _experienceOfEmployee = experienceOfEmployee;
        }

        public string NameOfEmployee { get => _nameOfEmployee; set => _nameOfEmployee = value; }
        public int IdOfEmployee { get => _idOfEmployee; set => _idOfEmployee = value; }
        public double SalaryOfEmployee { get => _salaryOfEmployee; set => _salaryOfEmployee = value; }
        public int ExperienceOfEmployee { get => _experienceOfEmployee; set => _experienceOfEmployee = value; }

        public static void PromoteEmployee(List<Employee> employeeList,IsPromotable IsPromotable)
        {
            foreach(Employee employee in employeeList)
            {
                if (IsPromotable(employee))
                {
                    Console.WriteLine($"{employee.NameOfEmployee} is Promoted.");
                }
            }
        }
    }
}
