using System;
using System.Drawing;
using Console = Colorful.Console;
namespace ConsoleCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Colorful.Console.SetWindowPosition(100,200);
            Colorful.Console.WriteAscii("Hello dot net 5.0.0", Color.Pink);
            Console.WriteLine(Color.Pink);
        }
    }
}
