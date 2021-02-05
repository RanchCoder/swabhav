using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_App.model;
namespace Person_App
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Person personA = new Person(15,"Vishal","male",1.47f,40.0f);

            PrintPersonInfo(personA);

            personA.Eat();
            PrintPersonInfo(personA);

            personA.Workout();
            PrintPersonInfo(personA);

            float bmiRatioValue = personA.CalculateBMIIndex();
            printBMIData(bmiRatioValue,personA);

            Console.ReadLine();
        }


        public static void PrintPersonInfo(Person p)
        {
            Console.WriteLine($"Age : {p.Age}," +
                $"\nname : {p.Name}," +
                $"\ngender : {p.Gender}," +
                $"\nheight : {p.Height}mtr" +
                $"\nweight : {p.Weight}kg");
        }

      
        public static void printBMIData(float bmiRatioValue,Person person)
        {
            Console.WriteLine($"\n\nHey! {person.Name}, since you are intrested in BMI check up, here is the result based on the data you provided.");
            Console.WriteLine($"{person.Name} your BMI Ratio is : {bmiRatioValue}");
            if(bmiRatioValue < 18.5)
            {
               
                Console.WriteLine($"{person.Name} you are underweight, you need to improve your nutrient and protien intake");
            }
            else if(bmiRatioValue >= 18.5 && bmiRatioValue <= 24.9){
                Console.WriteLine($"{person.Name} you are healthy, just stay on same track and you will have a happy & healthy life");
            }
            else if(bmiRatioValue >= 25.0 && bmiRatioValue <= 29.0)
            {
                Console.WriteLine($"{person.Name} you are overweight, a regular workout will do fine");
            }
            else if(bmiRatioValue >= 30.0)
            {
                Console.WriteLine($"{person.Name} you are obese. You need to consult a doctor as soon as possible.");
            }
        }
    }
}
