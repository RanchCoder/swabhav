using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleWinApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Case1();
            Console.ReadLine();
        }

        public static void Case1()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                      WinForm1 wf = new WinForm1();

            wf.Load += Log;
            Application.Run(wf);

           

        }
        public static void Log(object sender,EventArgs args)
        {
            
            Console.WriteLine("Inside named function");
            string filePath = @"C:\swabhav\Html\ConsoleWinApp\fileThroughWindow.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
              

                // Read and display lines from the file until 
                // the end of the file is reached. 
                sw.WriteLine($"Hello this is a text written after loading of winform");
            }

        }
    }
}
