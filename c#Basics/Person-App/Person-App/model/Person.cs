using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_App.model
{
    class Person
    {
        private int age;
        private string gender;
        private string name;
        private float height;
        private float weight;

        const float WEIGHT_INCREMENT = 0.05f;
        const float WEIGHT_DECREMENT = 0.02f;

        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Name { get => name; set => name = value; }
        public float Height { get => height; set => height = value; }
        public float Weight { get => weight; set => weight = value; }

        public Person(int age,string name,string gender,float height,float weight)
        {
            this.age = age;
            this.name = name;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
        }

        public Person(int age,string name)
        {
            this.age = age;
            this.name = name;           
            this.gender = "male";
            this.height = 1.47f;
            this.weight = 49.89f;
        }        

        public void Workout()
        {
            this.weight = this.weight - (this.weight * WEIGHT_DECREMENT);
        }

        public void Eat()
        {
            this.weight = this.weight + (this.weight * WEIGHT_INCREMENT);
        }

        public float CalculateBMIIndex()
        {
            float denominatorHeight = (float)Math.Pow(this.height,2);
            float bmi = this.weight / denominatorHeight;
            return bmi;
        }

        

        
    }
}
