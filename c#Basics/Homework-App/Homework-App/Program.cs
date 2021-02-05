using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_App
{
    abstract class Picasso : Nose
    {
        public int IMethod()
        {
            return 7;
        }
    }

    class Clown : Picasso { }

    class Acts : Picasso
    {
        public int IMethod()
        {
            return 5;
        }
    }
    class Program : Clown
    {
        public static void Main(string[] args)
        {
            Nose[] i = new Nose[3];
            i[0] = new Acts();
            i[1] = new Clown();
            i[2] = new Program();

            for(int j = 0; j < i.Length; j++)
            {
                Console.WriteLine($"{i[j].IMethod()}  {i[j].GetType().Name}");
            }
            Console.ReadLine();
        }






        //public static void PrintAl(ArrayList a)
        //{
        //    Console.WriteLine();
        //    foreach(string element in a)
        //    {
        //        Console.Write($"{element} ");
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    ArrayList a = new ArrayList();
        //    a.Add("zero");
        //    a.Add("one");
        //    a.Add("two");
        //    a.Add("three");
        //    PrintAl(a);
        //    if (a.Contains("three"))
        //    {
        //        a.Add("four");
        //    }
        //    a.Remove("two");
        //    PrintAl(a);
        //    if(a.IndexOf("four") != 4)
        //    {
        //        a.Add("4.2");
        //    }
            
        //    PrintAl(a);
        //    if (a.Contains("two"))
        //    {
        //        a.Add("2.2");
        //    }
        //    PrintAl(a);
        //    Console.ReadLine();
        //}


    }
}
