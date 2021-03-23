using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToCSV.Model
{
    class Employee
    {
        private int _employeeId;
        private string _employeeName;
        private string _employee_designation;
        private int _employeeSalary;
        private int _empDeptNo;

        public int EmployeeId { get => _employeeId; set => _employeeId = value; }
        public string EmployeeName { get => _employeeName; set => _employeeName = value; }
        public string Employee_designation { get => _employee_designation; set => _employee_designation = value; }
        public int EmployeeSalary { get => _employeeSalary; set => _employeeSalary = value; }
        public int EmpDeptNo { get => _empDeptNo; set => _empDeptNo = value; }
    }
}
