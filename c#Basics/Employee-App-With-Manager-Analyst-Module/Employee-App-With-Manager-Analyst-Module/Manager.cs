using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App_With_Manager_Analyst_Module
{
    class Manager : Employee
    {
        private float bonusPercentage = 0.1f;
        
        

        public Manager(int id, string name, float salary, DateTime date,string designation) : base(id, name, salary, date,designation)
        {
            this.TravelAllowance = this.Salary * 0.1f;
            this.HouseRentAllowance = this.Salary * 0.3f;
            this.DearnessAllowance = this.Salary * 0.95f;
        }


       

        public float SalaryWithBonus()
        {
            return this.Salary + (this.Salary * this.bonusPercentage);
        }

        public override float ComputeSalaryWithAllowance()
        {
            

            return this.Salary + this.TravelAllowance + this.HouseRentAllowance + this.DearnessAllowance;
        }

    }

}
