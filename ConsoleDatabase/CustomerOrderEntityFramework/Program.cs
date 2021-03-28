using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerOrderEntityFramework.Model;
namespace CustomerOrderEntityFramework
{
    class Program
    {
        public static CustOrderDBContext db = new CustOrderDBContext(); 
        static void Main(string[] args)
        {
            CreateTable();
            //ShowUserOrderDetail();
            //SortCustomerOrderByName();
            //SortCustomerOrderByPrice();
            //SumOfAllOrder();
            //AverageOfAllOrder();
            Console.ReadLine();
        }

        private static void CreateTable()
        {
            var order1 = new Order(){ Id = 1, Name = "Samsung Note 3", Price = 15000 };
            var order2 = new Order(){ Id = 2, Name = "MI Note 4", Price = 25000 };
            var order3 = new Order(){ Id = 3, Name = "Iphone 8", Price = 35000 };
            var order4 = new Order() { Id = 4, Name = "Iphone 9", Price = 65000 };


            var customer1 = new Customer(){ Id = 1, Name = "vishal", Address = "Mumbai" };
            var customer2 = new Customer(){ Id = 2, Name = "Dinesh", Address = "Pune" };
            var customer3 = new Customer(){ Id = 3, Name = "Rohnak", Address = "Ahemdabad" };

            order1.CustomerNo = customer1;
            order2.CustomerNo = customer2;
            order3.CustomerNo = customer3;
            order4.CustomerNo = customer1;



            customer1.Orders.Add(order1);
            customer2.Orders.Add(order2);
            customer3.Orders.Add(order3);
            
            db.Customers.Add(customer1);
            db.Customers.Add(customer2);
            db.Customers.Add(customer3);
            db.SaveChanges();
            Console.WriteLine("Table added to Database");
        }

        public static void ShowUserOrderDetail()
        {
            var orderSummary = db.Customers.Join(db.Orders,
                customer => customer.Id,
                order => order.Id,
                (customer, order) => new { 
                    name=customer.Name,
                    address=customer.Address,
                    productName=order.Name,
                    price = order.Price 
                });
            foreach(var customerOrder in orderSummary)
            {
                Console.WriteLine($"Customer Name : {customerOrder.name} | Customer Address : {customerOrder.address} " +
                    $"| product Name : {customerOrder.productName} | product price : {customerOrder.price}");
            }
        }

        public static void SortCustomerOrderByName()
        {
            Console.WriteLine("Showing Customer order by name in ascending order");

            var orderSummary = db.Customers.Join(db.Orders,
                customer => customer.Id,
                order => order.Id,
                (customer, order) => new {
                    name = customer.Name,
                    address = customer.Address,
                    productName = order.Name,
                    price = order.Price
                }).OrderBy(x => x.name);
            foreach (var customerOrder in orderSummary)
            {
                Console.WriteLine($"Customer Name : {customerOrder.name} | Customer Address : {customerOrder.address} " +
                    $"| product Name : {customerOrder.productName} | product price : {customerOrder.price}");
            }
        }


        public static void SortCustomerOrderByPrice()
        {
            Console.WriteLine("Sorting Customer orders By Price");

            var orderSummary = db.Customers.Join(db.Orders,
                customer => customer.Id,
                order => order.Id,
                (customer, order) => new {
                    name = customer.Name,
                    address = customer.Address,
                    productName = order.Name,
                    price = order.Price
                }).OrderBy(x => x.price);
            foreach (var customerOrder in orderSummary)
            {
                Console.WriteLine($"Customer Name : {customerOrder.name} | Customer Address : {customerOrder.address} " +
                    $"| product Name : {customerOrder.productName} | product price : {customerOrder.price}");
            }
        }

        public static void SumOfAllOrder()
        {
            Console.WriteLine("Sum Of All Orders Price ");
            Console.WriteLine($"Total Amount Of All Orders : ${db.Orders.Sum(x=>x.Price)}");
        }

        public static void AverageOfAllOrder()
        {
            Console.WriteLine("Average Of All Orders ");
            Console.WriteLine($"Average Amount Of Orders : ${db.Orders.Average(x => x.Price)}");

        }
    }
}
