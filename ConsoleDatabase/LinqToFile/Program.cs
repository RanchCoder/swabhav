using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Windows\System32";

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(folderPath);

            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);

            var files = fileList.OrderBy(x=>x.FullName).Take(3);

            var biggestFile = fileList.OrderByDescending(x => (x.Length)).Take(1);
            var directoryName = fileList.OrderBy(x => x.Directory.Name).Take(3);

            IEnumerable<System.IO.DirectoryInfo> directoryList = dir.GetDirectories("*.*", System.IO.SearchOption.TopDirectoryOnly);

            var largestDirectories = directoryList.OrderByDescending(x => x.GetDirectories().Length).Take(3);



            Console.WriteLine("top 3  file :: ");
            foreach (System.IO.FileInfo file in files)
            {

                Console.WriteLine($"{file.FullName} | size :  {file.Length}");
            }




            Console.WriteLine("\nbiggest file :: ");
            foreach (System.IO.FileInfo file in biggestFile)
            {

                Console.WriteLine($"{file.FullName} | size :  {file.Length}");
            }

            Console.WriteLine("\nDirector Name of file :: ");
            foreach (System.IO.FileInfo file in directoryName)
            {

                Console.WriteLine($"Directory Name : {file.Directory.Name} | file Name : {file.Name}");
            }


            Console.WriteLine("\nlargest directory :: ");
            foreach (System.IO.DirectoryInfo directoryInfo in largestDirectories)
            {

                Console.WriteLine($"Directory Name : {directoryInfo.FullName} | size : {directoryInfo.}");
            }



            Console.ReadLine();
        }
    }
}
