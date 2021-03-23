using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemo2.Model;

namespace EntityFrameworkDemo2
{
    class Program
    {
        static UserDBContext db = new UserDBContext();
        static void Main(string[] args)
        {
            CreateUser();
            Console.ReadLine();
        }

        public static void CreateUser()
        {
            User[] users = {
                new User { Id = 1, Name = "vishal", Hobby = "reading" },
                new User { Id = 2, Name = "rampaul", Hobby = "cricket" },
                new User { Id = 3, Name = "dinakaran", Hobby = "politics" }
            };

            foreach(User user in users)
            {
                db.SaveChanges();
            }
           
        }
    }
}
