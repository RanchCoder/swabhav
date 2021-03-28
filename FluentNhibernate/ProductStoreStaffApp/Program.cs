using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStoreStaffApp.Entity;

namespace ProductStoreStaffApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var BigBazaar = new Store { Name = "BigBazzar"};
                    var DMart = new Store { Name = "DMart" };

                    var Potatoe = new Product { Name = "Potatoe", Price = 40 };
                    var Cheese = new Product { Name = "cheese", Price = 140 };
                    var muffins = new Product { Name = "muffins", Price = 60 };
                    var toast = new Product { Name = "toast", Price = 130 };
                    var cabbage = new Product { Name = "cabbage", Price = 30 };

                    var vishal = new Employee { FirstName="Vishal",LastName="Singh"};
                    var jack = new Employee { FirstName = "Jack", LastName = "Renauld" };
                    var gabriel = new Employee { FirstName = "gabriel", LastName = "stonor" };
                    var hastings = new Employee { FirstName = "hastings", LastName = "captain" };
                    var hautet = new Employee { FirstName = "hautet", LastName = "commander" };
                    var giurad = new Employee { FirstName = "giurad", LastName = "steven" };

                    SaveProductToStore(BigBazaar,Potatoe,Cheese,toast,muffins);
                    SaveProductToStore(DMart,Cheese,toast,cabbage,muffins,Potatoe);

                    AddEmployeeToStore(BigBazaar,vishal,jack,gabriel);
                    AddEmployeeToStore(DMart,hastings,hautet,giurad);

                    session.SaveOrUpdate(BigBazaar);
                    session.SaveOrUpdate(DMart);
                    transaction.Commit();

                }

                Console.ReadKey();
            }
            Console.ReadLine();
        }
        public static void SaveProductToStore(Store store, params Product[] products)
        {
            foreach(Product product in products)
            {
                store.AddProduct(product);
            }
        }

        public static void AddEmployeeToStore(Store store, params Employee[] employees)
        {
            foreach(Employee employee in employees)
            {
                store.AddEmployee(employee);
            }
        }
    }
}
