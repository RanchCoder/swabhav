using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectangleApp.model;
namespace RectangleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using constructor to set Values
            Rectangle r = new Rectangle();

            //r.Height = -1;
            //r.Width = 23;
            //r.Color = "red";
            //r.SetHeight(10);

            //r.SetWidth(20);

            ////setting Color other than red, blue, green and setting it back to black as default
            //r.SetColor("purple");
            
            Console.WriteLine($"Heigth: {r.Height = 122} , width: {r.Width} , color : {r.Color}");
            Console.ReadLine();
        }
    }
}
