using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ContactApi.Token
{
    public class JwtAuthorization : Attribute, IAuthorizationFilter
    {
        public string Role { get; set; }
        private ICustomTokenManager _tokenManager;

        public JwtAuthorization() { }
        public JwtAuthorization(string role)
        {
            this.Role = role;
        }

        public bool IsValidToken(string authToken)
        {
            return _tokenManager.VerifyToken(authToken);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _tokenManager = (ICustomTokenManager)context.HttpContext.RequestServices.GetService(typeof(ICustomTokenManager));
            if(context != null)
            {
                var token = context.HttpContext.Request.Headers["token"].ToString();
                string role = _tokenManager.GetUserInfoByToken(token);
                if (IsValidToken(token) && role != null && role == Role)
                {
                    return;
                }

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult("NotAdminRole")
                {
                    Value = new
                    {
                        Status = "Error",
                        Message = "Invalid Role or token"
                    },
                };

            }
        }
    }
}
