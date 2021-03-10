using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDeligateApp
{
    public delegate void DMathOperation(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            Case2();
            Console.ReadLine();
        }


        public static void Add(int a, int b)
        {
            //write logic of addition
            Console.WriteLine($"addition : " + (a + b));
        }

        public static void Subtract(int a, int b)
        {
            //write logic of sub

            Console.WriteLine($"subraction : " + (a - b));
        }

        public static void Multiply(int a, int b)
        {
            //write logic of sub

            Console.WriteLine($"multiplication : "+ a * b);
        }

        public static void Division(int a, int b)
        {
            //write logic 

            Console.WriteLine($"division : " + a / b);
        }

        public static void Case1()
        {
            Console.WriteLine("Case 1 : \n");


            DMathOperation d = Add;
            d(10, 20);
            d = Subtract;
            d(30, 20);
            d = Multiply;
            d(30, 20);
            d = Division;
            d(10, 2);

        }

        public static void Case2()
        {
            DMathOperation[] dMathOperations = new DMathOperation[4];
            DMathOperation add = Add;
            dMathOperations[0] = add;

            DMathOperation subtract = Subtract;
            dMathOperations[1] = subtract;

            DMathOperation multiply = Multiply;
            dMathOperations[2] = multiply;

            DMathOperation division = Division;
            dMathOperations[3] = division;

            PerformOperation(dMathOperations);
        }


        public static void PerformOperation(DMathOperation[] dMathOperations)
        {
            Console.WriteLine($"Performing array of operations");
            foreach(DMathOperation delegateOperation in dMathOperations)
            {
                delegateOperation(10, 20);
            }
        }


    }
}