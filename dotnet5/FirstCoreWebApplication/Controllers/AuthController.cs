using FirstCoreWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FirstCoreWebApplication.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost,Route("Login")]
        public ActionResult PostLogin([FromBody] Login loginData)
        {
            if (loginData == null)
            {
                return BadRequest("Invalid user");
            } 
            if(loginData.Username == "Vishal" && loginData.Password == "Vishal")
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey390293"));
                    var signinCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                         issuer: "http://localhost:55307",
                         audience: "http://localhost:55307",
                         claims:new List<Claim>(),
                         expires:DateTime.Now.AddMinutes(30),
                         signingCredentials:signinCredentials
                         
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = token});

            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
