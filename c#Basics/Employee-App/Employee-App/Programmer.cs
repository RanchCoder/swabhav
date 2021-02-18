using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App
{
    public class Programmer : Employee
    {
        private float bonus = 0.2f;
        public Programmer(int id, string name, float salary, DateTime date) : base(id, name, salary, date)
        {

        }

        public float Bonus { get => bonus;}

        public float ProgrammerSalaryWithBonus()
        {
            return this.Salary + (this.Salary * this.Bonus);
        }
    }
}
