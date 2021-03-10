using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPatternMealApp.Model;
namespace BuilderPatternMealApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MealBuilder vegMealBuilder = new MealBuilder();
            Meal vegMeal = vegMealBuilder.PrepareVegMeal();
            vegMeal.ShowMealItems();
            Console.WriteLine($"\nTotal Price : Rs.{vegMeal.GetFinalCost()}/-");
            Meal nonVegMeal = vegMealBuilder.PrepareNonVegMeal();
            nonVegMeal.ShowMealItems();
            Console.WriteLine($"\nTotal Price : Rs.{nonVegMeal.GetFinalCost()}/-");
            Console.ReadLine();
        }
    }
}
