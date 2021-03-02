using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethodPatternApp.Model;
namespace TemplateMethodPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            University mumbaiUniversity = new TechnicalCourse();
            mumbaiUniversity.StartProcess();
            Console.WriteLine();
            University puneUniversity = new NonTechnicalCourse();
            puneUniversity.StartProcess();

            Console.ReadLine();
        }
    }
}
