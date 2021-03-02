using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePatternApp.Model;
namespace TemplatePatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game1 = new Cricket();
            game1.Play();
            Console.WriteLine("\n\n");

            Game game2 = new Football();
            game2.Play();
            Console.ReadLine();
        }
    }
}
