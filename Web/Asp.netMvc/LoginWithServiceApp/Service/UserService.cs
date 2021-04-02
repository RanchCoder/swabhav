using LoginWithServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginWithServiceApp.Service
{
    public class UserService
    {

        public IList<User> UserList = new List<User>();

        public void AddUser(User user)
        {
            this.UserList.Add(user);
        }

        public bool IsValidUser(User u)
        {
            bool flag = false;
            
                if(u.UserName == "vishal" && u.Password == "pass1234")
                {
                    flag = true;
                }
            

            return flag; 
        }
    }
}