using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model
{
    class Meal
    {
        private List<Item> _mealItems = new List<Item>();
        private const int EMPTY_LIST = 0;
        public void AddItemToMeal(Item item)
        {
            if (!_mealItems.Contains(item))
            {
                _mealItems.Add(item);

            }
        }

        public float GetFinalCost()
        {
            float costOfMeal = 0;
            if(_mealItems.Count > EMPTY_LIST)
            {
                foreach(Item itemInList in _mealItems)
                {
                    costOfMeal += itemInList.Price(); 
                }
            }
            return costOfMeal;
        }

        public void ShowMealItems()
        {
            if(_mealItems.Count > EMPTY_LIST)
            {
                Console.WriteLine($"\n*********** LIST ITEMS ***********");
                foreach(Item itemInList in _mealItems)
                {
                    Console.WriteLine($"\nName : {itemInList.Name()}" +
                        $"\nPacking of Item : {itemInList.Packing().Pack()}" +
                        $"\nPrice of Item : Rs.{itemInList.Price()}/-");
                }
            }
        }



    }
}
