
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CustomerNHibernateApp.Model;

namespace CustomerNHibernateApp
{
    class Program
    {

        static void Main(string[] args)
        {

                using (var session = NHibernatHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var contact = new Contact()
                        {
                            FirstName = "Rahul",
                            LastName = "Shetye",
                            PhoneNo = 989273965
                        };
                        session.Save(contact);
                        transaction.Commit();
                        Console.WriteLine("Success");

                    }
                }
                Console.ReadLine();
            }

        public static void Insert(string firstname , string lastname,int mobileno) 
        {
          
            using (var session = NHibernatHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var contact = new Contact { FirstName = firstname, LastName = lastname, PhoneNo = mobileno };


                    session.Save(contact);

                    transaction.Commit();
                }
            
                
            }
        }
    }
}