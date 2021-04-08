using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace TodoListMVC.CustomerFilter
{
    public class AuthorizeAccess : ActionFilterAttribute, IAuthenticationFilter
    {
        public AuthorizeAccess()
        {
            Console.WriteLine("Filter Called");
        }
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session["AuthenticUser"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Login"

                };
            }
        }
    }
}