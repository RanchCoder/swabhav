using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App
{
    public class Employee
    {
        private int id;
        private string name;
        private float salary;
        private DateTime date;
        
        

        public Employee(int id,string name,float salary,DateTime date)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.date = date;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float Salary { get => salary; set => salary = value; }
        public DateTime Date { get => date; set => date = value; }
        

        
    }
}
