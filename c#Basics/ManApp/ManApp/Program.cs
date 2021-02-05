using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Case1();
            Case2();
            Case3();
            Case4();
            Console.ReadLine();
        }

        public static void Case1()
        {
            Console.WriteLine($"************Case 1*********** ");
            Man x = new Man();
            x.Plays();
            x.Read();
        }

        public static void Case2()
        {
            Console.WriteLine($"************Case 2*********** ");
            Boy y = new Boy();
            y.Plays();
            y.Eats();
            y.Read();
        }

        public static void Case3()
        {

            Console.WriteLine($"************Case 3*********** ");
            Man x;
            x = new Boy();
            x.Plays();            
            x.Read();


        }

        public static void Case4()
        {
            Console.WriteLine($"************Case 4*********** ");
            AtParks(new Man());
            AtParks(new Boy());
            AtParks(new Kid());
            AtParks(new Infant());
            
        }

        public static void Case5()
        {
            Object x;
            x = 10;
            Console.WriteLine(x);
            x = "Abc";
            Console.WriteLine(x);
            x = new Man();
            Console.WriteLine(x.Plays());
        }

        public static void AtParks(Man m)
        {
            Console.WriteLine("************At Parks**************");
            m.Plays();
        }



    }
}
