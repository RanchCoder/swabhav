using FacadePatternApp.FacadeShoppingApp;
using FacadePatternApp.Model;
using System;
using System.Collections.Generic;

namespace FacadePatternApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program shop = new Program();
            AmazonApp amazonApp = new AmazonApp();
            List<InventoryItem> itemList =  amazonApp.SpecifyRequirements();
            shop.PrintInventoryList(itemList);
            Console.ReadLine();
        }

        public void PrintInventoryList(List<InventoryItem> itemList)
        {
            Console.WriteLine("\nShowing the Inventory List");
            Console.WriteLine("ID | NAME  | PRICE");
            foreach(var item in itemList)
            {
                Console.WriteLine($"{item.Id}  | {item.Name} | {item.Price}");
            }
        }
    }

    
}
