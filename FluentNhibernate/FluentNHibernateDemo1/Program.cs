using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Update();
            Console.ReadLine();
        }

        public static void Insert(string firstname,string lastname)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var friend = new Friend
                    {
                        FirstName = firstname,
                        LastName = lastname,
                    };
                    session.Save(friend);
                    transaction.Commit();
                    Console.WriteLine($"Friend record added");
                }
                Console.ReadKey();
            }
        }

        public static void Update()
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var friend = session.Get<Friend>(1);
                    Console.WriteLine($"Retreived record : {friend.FirstName} {friend.LastName}");

                    Console.WriteLine($"Changing the first name {friend.FirstName} to Donald");
                    friend.FirstName = "Donald";
                    session.Update(friend);

                    Console.WriteLine("\nRecord after change");
                    var friends = session.CreateCriteria<Friend>().List<Friend>();
                    foreach(var dost in friends)
                    {
                        Console.WriteLine($"ID : {dost.Id} , Firstname : {dost.FirstName} , Lastname : {dost.LastName}");
                    }
                    transaction.Commit();
                }
            }
            
        }
    }
}
