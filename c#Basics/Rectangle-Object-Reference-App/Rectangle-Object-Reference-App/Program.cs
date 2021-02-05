using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle_Object_Reference_App.model;

namespace Rectangle_Object_Reference_App
{
    class Program
    {
        public static void PrintRectangleInfo(Rectangle rectObj)
        {
            Console.WriteLine($"\n {nameof(rectObj)}  height : {rectObj.GetHeight()} , width :  {rectObj.GetWidth()}");
            Console.WriteLine($"\nHashCode : ${rectObj.GetHashCode()}");
        }

        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle();
            r1.SetHeight(10);
            r1.SetWidth(20);

            //Console.WriteLine($"hash code of r1 {r1.GetHashCode()}" );
            //Console.WriteLine($"height width of  r1 {r1.GetHeight()} ,  {r1.GetWidth()}");

            Rectangle r2 = r1;

            r2.SetHeight(r2.GetHeight() + 1);
            r2.SetWidth(r2.GetWidth() + 1);

            PrintRectangleInfo(r1);
            PrintRectangleInfo(r2);

            Rectangle r3 = new Rectangle();
            r2 = r3;
            PrintRectangleInfo(r3);

            //anonymous object , each time a new memory location on the heap is created and returned.
            Console.WriteLine(new Rectangle().GetHashCode());
            Console.WriteLine(new Rectangle().GetHashCode());


            
            Console.ReadLine();

        }
    }
}
