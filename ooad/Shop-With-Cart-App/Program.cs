using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_With_Cart_App.model;
namespace Shop_With_Cart_App
{
    class Program
    {
        public static List<Guid> guidsAllocated = new List<Guid>();

        
        static void Main(string[] args)
        {
            
            Product product_Parle_Biscuit = new Product(GenerateRandomId(),"Parle Biscuit",10,0.2);
            Product product_Lays_Chip = new Product(GenerateRandomId(),"Lays Chips",10,0.05);
            Product product_Pepsi_SoftDrink = new Product(GenerateRandomId(),"Pepsi",25,0.2);
            Product product_Denim_Shirt = new Product(GenerateRandomId(), "Diesel Shirts", 1000, 0.5);
            Product product_Cricket_Bat = new Product(GenerateRandomId(), "Cricket Bat", 650, 0.2);
            Product product_Instant_Noodles = new Product(GenerateRandomId(), "Maggie Instant Noodles", 25, 0.1);

            List<Product> productList = new List<Product>();
            productList.Add(product_Parle_Biscuit);
            productList.Add(product_Lays_Chip);
            productList.Add(product_Pepsi_SoftDrink);
            productList.Add(product_Denim_Shirt);
            productList.Add(product_Cricket_Bat);
            productList.Add(product_Instant_Noodles);


            LineItem item1 = new LineItem(GenerateRandomId(),5,product_Instant_Noodles);

            LineItem item2 = new LineItem(GenerateRandomId(), 2, product_Cricket_Bat);
            LineItem item3 = new LineItem(GenerateRandomId(), 4, product_Cricket_Bat);


            Order orderOfCustomer1 = new Order(GenerateRandomId(),DateTime.Now);
            orderOfCustomer1.AddItem(item1);
            orderOfCustomer1.AddItem(item2);
            orderOfCustomer1.AddItem(item3);
            Customer customer1 = new Customer(GenerateRandomId(),"vishal","mumbai");

            customer1.AddOrder(orderOfCustomer1);

            PrintDetails(customer1);
            
            Console.ReadLine();
        }


        public static void PrintDetails(Customer customerInstance)
        {
            customerInstance.OrdersByCustomer.ForEach(Console.WriteLine);
        }

       


        public static Guid GenerateRandomId()
        {
            Guid guidToBeAllocated = Guid.NewGuid();
            if (guidsAllocated.Contains(guidToBeAllocated))
            {
                return Guid.NewGuid();
            }
            guidsAllocated.Add(guidToBeAllocated);
            return guidToBeAllocated;
        }

       

    }
}
