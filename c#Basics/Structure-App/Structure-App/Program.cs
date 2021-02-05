using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure_App
{
    class Program
    {
        public void modify(int x , int y)
        {
            x = 0;
            y = 0;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Point p1 = new Point();
            p1.x = 10;
            p1.y = 20;
            Console.WriteLine("Before calling modify");
            Console.WriteLine($"x = {p1.x} ,y =  {p1.y}");

            p.modify(p1.x,p1.y);
            Console.WriteLine("Before calling modify");
            Console.WriteLine($"x = {p1.x} ,y =  {p1.y}");            
            Console.ReadLine();
        }
    }
}
