using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Serialization_App
{
    [Serializable]
    class Program
    {
        public int a;
        public int b; 
        String abc;

        public Program(int a, int b, string abc)
        {
            this.a = a;
            this.b = b;
            this.abc = abc;
        }
        static void Main(string[] args)
        {
            Program instanceOfProgram = new Program(10,20,"text string");
            string filePath = @"D:\FileOperationInC#\serializedObjectData.txt";
            
            FileStream fileStreamForObjectSerialization = new FileStream(filePath,FileMode.OpenOrCreate);
            
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStreamForObjectSerialization,instanceOfProgram);
            fileStreamForObjectSerialization.Close();
            Console.ReadLine();
        }
    }
}
