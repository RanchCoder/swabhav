using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Operation_Reading_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\FileOperationInC#\Book1.csv";
            if (File.Exists(filePath))
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                
                string line = "";
                using(StreamReader sr = new StreamReader(fileStream))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

            }
            else
            {
                Console.WriteLine("File not available");
            }
            Console.ReadLine();
        }
    }
}
