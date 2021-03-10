using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPatternMealApp.Model.MenuItems;
namespace BuilderPatternMealApp.Model
{
    class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal vegMeal = new Meal();
            vegMeal.AddItemToMeal(new VegBurger());
            vegMeal.AddItemToMeal(new Pepsi());
            return vegMeal;
        }

        public Meal PrepareNonVegMeal()
        {
            Meal nonVegMeal = new Meal();
            nonVegMeal.AddItemToMeal(new NonVegBurger());
            nonVegMeal.AddItemToMeal(new CocaCola());
            return nonVegMeal;
        }
    }
}
