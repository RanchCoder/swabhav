using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App_With_Manager_Analyst_Module
{
    
        class Employee
        {
            private int id;
            private string name;
            private float salary;
            private DateTime date;
            private float houseRentAllowance;
            private float dearnessAllowance;
            private float travelAllowance;
            private string designation;


        public Employee(int id, string name, float salary, DateTime date,string designation)
            {
                this.id = id;
                this.name = name;
                this.salary = salary;
                this.date = date;
                this.designation = designation;
            }
            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public float Salary { get => salary; set => salary = value; }
            public DateTime Date { get => date; set => date = value; }

            public float HouseRentAllowance { get => houseRentAllowance; set => houseRentAllowance = value; }
            public float DearnessAllowance { get => dearnessAllowance; set => dearnessAllowance = value; }
            public float TravelAllowance { get => travelAllowance; set { travelAllowance = value;} }

        public string Designation { get => designation; set => designation = value; }

        public virtual float ComputeSalaryWithAllowance()
           {
             return this.Salary + this.HouseRentAllowance + this.DearnessAllowance + this.TravelAllowance;
           }
        }
    
}
