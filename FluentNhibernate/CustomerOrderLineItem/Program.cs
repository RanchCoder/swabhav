using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerOrderLineItem.Entity;
using CustomerOrderLineItem.Mapper;
namespace CustomerOrderLineItem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize();
            // ShowOrderByCustomerId();
            // CustomerWhoOrderedProduct();
           // ProductOrderedTheMost();
            CustomerWithMostOrder();
            Console.ReadLine();
        }

        public static void CustomerWithMostOrder()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customerOrderData = session.Query<Customer>()
                        .Join(session.Query<Order>(), customer => customer.Id, order => order.Id, (customer, order) => new
                        {
                            customerId = customer.Id,
                            orderId = order.Id,
                            countOrder = customer.Orders,
                        });


                    Console.WriteLine($"Showing Customer order count...");
                    foreach (var customerOrder in customerOrderData)
                    {
                        Console.WriteLine($"\ncustomer Name : {customerOrder.customerId} " +
                            $"| count : {customerOrder.countOrder} ");
                    }
                }
            }
        }

        public static void ProductOrderedTheMost()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customerOrderData = session.Query<Order>()
                        .Join(session.Query<LineItem>(), order => order.Id, lineitem => lineitem.Order.Id, (order, lineItem) => new
                        {
                            productQuantity = lineItem.Quantity,
                            productName = lineItem.ProductType.Name,
                            productId = lineItem.ProductType.Id,
                        }).OrderByDescending(x => x.productQuantity).Take(1);
                        

                    Console.WriteLine($"Showing Product Ordered the Most...");
                    foreach (var customerOrder in customerOrderData)
                    {
                        Console.WriteLine($"\nProduct Name : {customerOrder.productName} " +
                            $"| Product Quantity : {customerOrder.productQuantity} ");
                    }
                }
            }

        }
        public static void ShowOrderByCustomerId()
        {
            PrintAllCustomerData();
            Console.Write("\nSelect a customer Id : ");
            int id = Int32.Parse(Console.ReadLine());
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customerOrderData = session.Query<Order>()
                        .Join(session.Query<LineItem>(), order => order.Id, lineitem => lineitem.Order.Id, (order, lineItem) => new
                        {
                            customerId = order.Customer.Id,
                            productName = lineItem.ProductType.Name,
                            productPrice = lineItem.ProductType.Price,
                            productQuantity = lineItem.Quantity
                        })
                        .Where(x=>x.customerId == id);

                    Console.WriteLine($"Showing order for customer with Id : {id}");
                    foreach(var customerOrder in customerOrderData)
                    {
                        Console.WriteLine($"Product Name : {customerOrder.productName} " +
                            $"| Product Quantity : {customerOrder.productQuantity} " +
                            $"| Product Price : {customerOrder.productPrice}" +
                            $" |Total Price Rs.{customerOrder.productPrice * customerOrder.productQuantity}/-");
                    }
                }
            }
        }



        public static void CustomerWhoOrderedProduct()
        {
            PrintAllProduct();
            Console.Write("Enter a product id for which you want to see customers.. ");
            int id = Int32.Parse(Console.ReadLine());
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customerOrderData = session.Query<Order>()
                        .Join(session.Query<LineItem>(), order => order.Id, lineitem => lineitem.Order.Id, (order, lineItem) => new
                        {
                            customerId = order.Customer.Id,
                            customerName = order.Customer.FirstName + " " + order.Customer.LastName,
                            productName = lineItem.ProductType.Name,
                            productId = lineItem.ProductType.Id,
                        })
                        .Where(x => x.productId == id);

                    Console.WriteLine($"Showing order for customer with Id : {id}");
                    foreach (var customerOrder in customerOrderData)
                    {
                        Console.WriteLine($"Customer Name : {customerOrder.customerName} " +
                            $"| ProductName : {customerOrder.productName} ");
                    }
                }
            }

        }

        public static void PrintAllCustomerData()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Console.WriteLine($"\n\nShowing all customer data");
                    var customers = session.CreateCriteria<Customer>().List<Customer>();
                    Console.WriteLine($"ID | FirstName | LastName | Address");
                    foreach(var customer in customers)
                    {
                        Console.WriteLine($"{customer.Id} | {customer.FirstName} | {customer.LastName} | {customer.Address}");
                    }
                }
                Console.ReadKey();
            }

        }

        public static void PrintAllProduct()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Console.WriteLine($"\n\nShowing all Product data");
                    var products = session.CreateCriteria<Product>().List<Product>();
                    Console.WriteLine($"ID | Product_Name | Product Price");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.Id} | {product.Name} | {product.Price}");
                    }
                }
                Console.ReadKey();
            }
        }

        public static void Initialize()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Product parleG = new Product { Name = "Parle G", Price = 10 };
                    Product bread = new Product { Name = "britiannia", Price = 20 };
                    Product rice = new Product { Name = "basmati rice", Price = 150 };
                    Product toast = new Product { Name = "marie toast", Price = 15 };
                    Product bun = new Product { Name = "bun and bakery", Price = 50 };
                    Product orange = new Product { Name = "orange", Price = 100 };
                    Product grapes = new Product { Name = "grapes", Price = 70 };

                    Product mobile = new Product { Name = "samsung 15", Price = 10000 };

                    LineItem item1 = new LineItem { Quantity = 10 };
                    LineItem item2 = new LineItem { Quantity = 15 };
                    LineItem item3 = new LineItem { Quantity = 52 };
                    LineItem item4 = new LineItem { Quantity = 14 };
                    LineItem item5 = new LineItem { Quantity = 23 };
                    LineItem item6 = new LineItem { Quantity = 20 };
                    LineItem item7 = new LineItem { Quantity = 40 };
                    LineItem item8 = new LineItem { Quantity = 50 };
                    LineItem item9 = new LineItem { Quantity = 20 };
                    LineItem item10 = new LineItem { Quantity = 50 };


                    item1.CreateLineItemForOrder(parleG);
                    item2.CreateLineItemForOrder(bread);
                    item3.CreateLineItemForOrder(rice);

                    item4.CreateLineItemForOrder(bun);
                    item5.CreateLineItemForOrder(toast);
                    item6.CreateLineItemForOrder(mobile);

                    item7.CreateLineItemForOrder(orange);
                    item8.CreateLineItemForOrder(mobile);
                    item9.CreateLineItemForOrder(grapes);
                    item10.CreateLineItemForOrder(parleG);

                    Customer customer1 = new Customer { FirstName = "vishal", LastName = "singh", Address = "mumbai" };
                    Customer customer2 = new Customer { FirstName = "prem", LastName = "choxy", Address = "bangalore" };
                    Customer customer3 = new Customer { FirstName = "andrew", LastName = "saxena", Address = "pune" };

                    Order order1 = new Order { };
                    Order order2 = new Order { };
                    Order order3 = new Order { };

                    order1.AddLineItemToOrder(item1);
                    order1.AddLineItemToOrder(item2);
                    order1.AddLineItemToOrder(item3);
                    order2.AddLineItemToOrder(item4);
                    order2.AddLineItemToOrder(item5);
                    order2.AddLineItemToOrder(item6);
                    order3.AddLineItemToOrder(item7);
                    order3.AddLineItemToOrder(item8);
                    order3.AddLineItemToOrder(item9);
                    order3.AddLineItemToOrder(item10);

                    customer1.AddOrderForCustomer(order1);
                    customer2.AddOrderForCustomer(order2);
                    customer3.AddOrderForCustomer(order3);

                    session.Save(parleG);
                    session.Save(bread);
                    session.Save(rice);
                    session.Save(bun);
                    session.Save(mobile);
                    session.Save(grapes);
                    session.Save(toast);
                    session.Save(orange);


                    session.Save(customer1);
                    session.Save(customer2);
                    session.Save(customer3);




                    session.Save(order1);
                    session.Save(order2);
                    session.Save(order3);



                    transaction.Commit();
                    Console.WriteLine("Tables Created");
                }
            }
                

        }
    }
}


