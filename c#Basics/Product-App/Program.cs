using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_App.model;

namespace Product_App
{
    class Program
    {

       
        public static double GetGrandTotal(List<Product> listOfProduct)
        {
            double grandTotal = 0;
            foreach(Product productInList in listOfProduct)
            {
                grandTotal += GetProductTotal(productInList); 
            }
            return grandTotal;
        }
        public static double GetProductTotal(Product product)
        {
            return product.Quantity * product.UnitPrice;
        }
        public static void PrintProductListDetails(ref List<Product> productsList)
        {
            Console.WriteLine($"\nProduct CART summary\n");
            Console.WriteLine($"\nId      Name       Quanity    Price");
            foreach(Product productInList in productsList)
            {
                Console.WriteLine($"{productInList.Id}      {productInList.Name}      {productInList.Quantity}      {GetProductTotal(productInList)}");
            }
            Console.WriteLine($"Grand Total : Rs {GetGrandTotal(productsList)}");
        }
        static void Main(string[] args)
        {
            Product product1 = new Product(1,"Cadbury     ",25.5,3);
            Product product2 = new Product(2,"Orange juice",15,2);
            Product product3 = new Product(3,"Milk        ",35.5,10);
            List<Product> productList = new List<Product>();
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            PrintProductListDetails(ref productList);
            Console.ReadLine();
        }
    }
}
