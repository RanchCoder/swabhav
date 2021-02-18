using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectangleApp.model;
namespace RectangleApp
{
    public class Program
    {
        public static int Area(int height,int width)
        {
            return 2 * height * width;
        }
        static void Main(string[] args)
        {
            //Using constructor to set Values
            Rectangle r1 = new Rectangle();
            Rectangle r2 = new Rectangle();

            r1.Height = -1;
            r1.Width = 23;
            r1.Color = "red";

            r2.Height = -1;
            r2.Width = 23;
            r2.Color = "red";
            //r.SetHeight(10);
            Console.WriteLine($"Are the two Rectangle Equal : {r1.Equals(r2)}");
            //r.SetWidth(20);

            ////setting Color other than red, blue, green and setting it back to black as default
            //r.SetColor("purple");

            //Console.WriteLine($"Heigth: {r.Height = 122} , width: {r.Width} , color : {r.Color}");
            Console.ReadLine();
        }
    }
}
