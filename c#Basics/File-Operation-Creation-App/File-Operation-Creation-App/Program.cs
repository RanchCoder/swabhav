using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Operation_Creation_App
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName  = @"D:\FileOperationInC#\student.txt";
            string studentName = "vishal";
            int studentId = 1;
            float cgpa = 5.6f;

            try{
                if(File.Exists(fileName)){
              Console.WriteLine("Yes it exists");

                

            }else{
                Console.WriteLine("No It does not exists");
                    FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                    using (StreamWriter sw = new StreamWriter(fs)) {
                        sw.WriteLine($"Student Name : {studentName} \nStudentId : {studentId} \nCGPA : {cgpa}");
                      
                    }
                        fs.Close();
                }

              

               
            }
            catch(Exception ex){
            
               Console.WriteLine(ex);
            }

            Console.ReadLine();

        }
    }
}
