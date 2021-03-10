using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositePatternApp.Model;
using System.IO;

namespace CompositePatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program start");

            ControlGroup html = new ControlGroup("html");
            ControlGroup body = new ControlGroup("body");
            ControlGroup div = new ControlGroup("div");

            html.AddControl(body);
            body.AddControl(div);

            div.AddControl(new Control("input", "text", "username"));
            div.AddControl(new Control("br"));
            StringBuilder sb = html.ParseHtml();
            WriteCode(sb);
            CreateHtmlFile(sb);
            Console.ReadLine();
        }

        public static void CreateHtmlFile(StringBuilder sb)
        {
            try
            {
                string filePath = @"C:\Users\machine\Desktop\assignment\abc.html";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
                {
                    file.WriteLine(sb.ToString()); // "sb" is the StringBuilder
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void WriteCode(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());
        }
    }
}
