using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLoginServiceApp.ViewModels
{
    public class UserCredentialVM
    {

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}