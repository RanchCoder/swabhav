using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_App.model;
namespace Student_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();

            Console.WriteLine("Case 1 : Ouput Without using Setter and calling Getters");
            
            //Case 1 calling getters without setters
            Console.WriteLine($"Name of Student : {s.GetName()} , Credit Point of Student : {s.GetCreditPoint()}");

            //Case 2 setting values using setters
            Console.WriteLine("\n\nCase 2 : Ouput With using Setter and calling Getters");
            s.setId(1);
            s.setName("Vishal");
            s.setCreditPoint(4.7f);
            Console.WriteLine($"Name of Student : {s.GetName()} , Id of Student : {s.GetId()} , Credit Point of Student : {s.GetCreditPoint()}");

            //Case 3 calling setters in Console.WriteLine()
            //Console.WriteLine(s.setName("Zeus"));


            Console.ReadLine();
        }
    }
}
