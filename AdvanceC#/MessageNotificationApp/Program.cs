using MessageNotificationApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNotificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User userVishal = new User("Vishal");
            User userZeus = new User("Zeus");
            User userRoshan = new User("Rohan");
            User userSid = new User("Sid");

            userVishal.AddFriend(userSid);
            userVishal.AddFriend(userZeus);
            
            userZeus.AddFriend(userVishal);
            userZeus.AddFriend(userRoshan);
            

            PrintAccountDetail(userVishal);
            PrintAccountDetail(userZeus);


            userVishal.SingleMessageSent += userZeus.OnReceivingMessage;

            userVishal.SendMessage("Hey! Zeus, How are you?");

            Console.ReadLine();

        }

        public static void PrintAccountDetail(User user)
        {
            Console.WriteLine($"\nUsername : {user.UserName}" +
                $"\n{user.UserName}'s Friends...");
            foreach(User userFriend in user.ShowFriends())
            {
                Console.WriteLine($"{userFriend.UserName}");
            }
        }
    }
}
