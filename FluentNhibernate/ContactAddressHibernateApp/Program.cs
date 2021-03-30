using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAddressHibernateApp.Model;

namespace ContactAddressHibernateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListNameOfAllContact();
           // ListContactWithAddress();
           // ListContactOfParticularLocation();
            Console.ReadLine();
        }

        public static void ListContactOfParticularLocation()
        {
            ListAllLocation();
            Console.Write($"Enter location for which you wish to see Contacts : ");
            string locationEntry = Console.ReadLine();

            using (var session = new NHibernateHelper().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Console.WriteLine("List all contact with their address");
                    var contactAddress = session.Query<Contact>().Join(session.Query<Address>(), contact => contact.Id, address => address.Contact.Id, (contact, address) => new
                    {
                        contactName = contact.FirstName + " " + contact.LastName,
                        contactAddress = address.Location,
                    }).Where(x=>x.contactAddress.Contains(locationEntry));

                    foreach(var contactInfo in contactAddress)
                    {
                        Console.WriteLine($"{contactInfo.contactName} ---- {contactInfo.contactAddress}");
                    }

                }
            }


        }

        public static void ListAllLocation()
        {
            using (var session = new NHibernateHelper().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var locationList = session.Query<Address>().Select(x => x.Location).Distinct();
                    Console.WriteLine("\nLocation");
                    foreach(var address in locationList)
                    {
                        Console.WriteLine($"{address}");
                    }
                }
            }
        }
        public static void ListContactWithAddress()
        {
            using (var session = new NHibernateHelper().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Console.WriteLine("List all contact with their address");
                    var contacts = session.CreateCriteria<Contact>().List<Contact>();
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"\n{contact.FirstName} || {contact.LastName} || {contact.PhoneNo}");
                        var addressOfContact = session.Query<Address>().Where(x => x.Contact.Id == contact.Id);
                        foreach(var address in addressOfContact)
                        {
                            Console.WriteLine($"==== Address Location : {address.Location}");
                        }
                    }
                }
            }
        }

        public static void ListNameOfAllContact()
        {
            using (var session = new NHibernateHelper().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var contacts = session.CreateCriteria<Contact>().List<Contact>();
                    Console.WriteLine($"FirstName | LastName | Phone Number");
                    foreach(var contact in contacts)
                    {
                        Console.WriteLine($"{contact.FirstName} || {contact.LastName} || {contact.PhoneNo}");
                    }
                }
            }
        }
        public static void Initialize()
        {
            using (var session = new NHibernateHelper().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var contactVishal = new Contact
                    {
                        FirstName = "vishal",
                        LastName = "Singh",
                        PhoneNo = 098482029,

                    };

                    var addressVishal1 = new Address
                    {
                        Location = "Kurla",

                    };

                    contactVishal.AddContactAddress(addressVishal1);
                    session.Save(contactVishal);
                    transaction.Commit();
                    Console.WriteLine("Table Created and Record Entered");
                }
            }
        }
    }
}
