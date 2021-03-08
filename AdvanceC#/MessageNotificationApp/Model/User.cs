using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNotificationApp.Model
{

    public delegate void MessageEventHandler(User user, string message);

    public class User
    {
        private string _userName;
        List<User> friendsList = new List<User>();
        public event MessageEventHandler SingleMessageSent;
        public event MessageEventHandler BrodcastMessageSent;
        public User(string userName)
        {
            _userName = userName;
        }

        public string UserName { get => _userName; set => _userName = value; }

        public void AddFriend(User user)
        {
            if (!friendsList.Contains(user))
            {
                friendsList.Add(user);

            }
        }

        public List<User> ShowFriends()
        {
            return friendsList;
        }

        public void SendMessage(string message)
        {
            OnMessageSent(message);
        }

        public void OnMessageSent(string message)
        {
            if(SingleMessageSent != null)
            {
                SingleMessageSent(this,message);
            }
        }



        public void OnReceivingMessage(User sender,string message)
        {
            Console.WriteLine($"\n{this.UserName} you have recieved a message from {sender.UserName}." +
                $"\nMessage content : {message}");
        }


    }
}
