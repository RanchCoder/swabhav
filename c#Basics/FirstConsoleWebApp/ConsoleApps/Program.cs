using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApps
{
    class Program
    {
        private static void PrintInfo(string value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintInfo(float value)
        {
            Console.WriteLine($"you have entered {value}");
        }


        private static void PrintInfo(int value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintInfo(double value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintInfo(bool value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintInfo(char value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintInfo(short value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintInfo(long value)
        {
            Console.WriteLine($"you have entered {value}");
        }

        private static void PrintNumber(int number)
        {
            number = number + 10;
            Console.WriteLine($"Number value in PrintNumber function : { number}");

        }

        private static void PrintArray(int[] array)
        {
          for(int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        public static string developerData(string[] arrayData)
        {
            return arrayData[1];
        }

        public static string getCourseDetailData(string[] arrayData) 
        {
            return arrayData[];

        }

        static void Main(string[] args)
        {

            string str = "I am learnign c#";
         

            //string url = "http://www.swabhav.com?developer=vishal";

           // string companyName = url.Substring(11,7);
            //string developerName = url.Substring(33,6);
            
            string url = "http://www.swabhav.com?developer=vishal&course=dotnet";



            string courseName = url.Substring(47, 6);
           // Console.WriteLine($"Company Name : {companyName} \n Developer Name : {developerName} \n courseName : {courseName}");



           url = "http://www.google.com?developer=vishal&course=dotnet";
          // companyName = url.Substring(11, 6);
            // Console.WriteLine($"\n\nCompany Name : {companyName} \n Developer Name : {developerName} \n courseName : {courseName}");

            string nameTesting = "abcd";
            //Console.WriteLine(nameTesting.GetHashCode());
            // Console.WriteLine(nameTesting.ToUpper().GetHashCode());
            // Console.WriteLine(nameTesting.ToLower().GetHashCode());
            int number = 10;
            PrintNumber(number);

            //Console.WriteLine($"Number value in main : {number}");


            int[] array = {10,20,30,40};

            //Console.WriteLine("Array before calling PrintArray Method");
            for (int i = 0; i < array.Length; i++)
            {
            //    Console.WriteLine($"arr[{i}] = {array[i]}");
            }

            PrintArray(array);

           // Console.WriteLine("Array after calling PrintArray Method");
            for(int i = 0; i < array.Length; i++)
            {
           //     Console.WriteLine($"arr[{i}] = {array[i]}");
            }
            char[] charParamForSplitting = {'.','?','&'};
            string[] urlSplitter = url.Split(charParamForSplitting);
            string companyName = "";
            string developerName = "";
            string courseDetail = "";
            for(int i = 0; i < urlSplitter.Length; i++)
            {
                if (i == 1) companyName = urlSplitter[i];
                if(i == 3)
                {
                    char[] developerCharParams = {'='};
                    string[] developersData = urlSplitter[i].Split(developerCharParams);
                    developerName = developerData(developersData);
                    
                }
                if(i == 4)
                {
                    char[] courseCharParam = {'='};
                    string[] courseData = urlSplitter[i].Split(courseCharParam);
                    courseDetail = getCourseDetailData(courseData);
                }
            }
            Console.WriteLine($"Company Name {companyName} , developer Name {developerName} , course name {courseDetail}");
            Console.ReadLine();

        }
    }
}
