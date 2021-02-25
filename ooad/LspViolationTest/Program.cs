using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LspViolationTest.Model;
namespace LspViolationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(10,20);
            Console.WriteLine($"For Rectangle is width same after height change : {Should_Not_Change_Width_If_Height_Changes(r1)}");

            Square s1 = new Square(10);
            Console.WriteLine($"For Square is width same after height change : {Should_Not_Change_Width_If_Height_Changes(s1)}");

            Console.ReadLine();

        }

        public static bool Should_Not_Change_Width_If_Height_Changes(Rectangle obj)
        {
            int before = obj.Breadth;
           

            obj.Length = obj.Length + 10;
            int after = obj.Breadth;
          
            if(before == after)
            {
                return true;
            }
            return false;

        }
    }
}
