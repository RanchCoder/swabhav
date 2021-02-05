using System;

using System.IO;

namespace Welcome_App
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i < 41; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
