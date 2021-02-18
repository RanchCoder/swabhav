using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_App.model
{
    public class Student
    {
        private int id;
        private string name;
        private float creditPoint;

        public int GetId() {
            return this.id;        
        }

        public string GetName()
        {
            return this.name;
        }

        public float GetCreditPoint()
        {
            return this.creditPoint;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        
        public void SetCreditPoint(float creditPoint)
        {
            this.creditPoint = creditPoint;
        }
    }
}
