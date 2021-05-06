using ContactApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Token
{
    public class CustomTokenManager : ICustomTokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private readonly IConfiguration configuration;
        private byte[] secretKey;

        public CustomTokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            tokenHandler = new JwtSecurityTokenHandler();
            secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JwtSecrectKey"));
        }

        public string CreateToken(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                       
                        new Claim("id",user.Id.ToString()),

                        new Claim("tenantId",user.TenantId.ToString()),
                        new Claim("username",user.Username),
                        new Claim("email",user.Email),
                        new Claim("role",user.Role),

                    }
                    ),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string CreateSuperAdminToken(SuperAdmin user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {

                        new Claim("id", user.Id.ToString()),



                        new Claim("email", user.Email),
                        new Claim("role",user.Role)

                    }
                    ),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetUserInfoByToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var jwtToken = tokenHandler.ReadToken(token.Replace("\"",string.Empty)) as JwtSecurityToken;
            var claim = jwtToken.Claims.FirstOrDefault(x=>x.Type == "role");
            
            if (claim != null) return claim.Value;
            return null;
        }

        public bool VerifyToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;
            SecurityToken securityToken;
            try
            {
                tokenHandler.ValidateToken(
                     token.Replace("\"", string.Empty),
                     new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                         ValidateLifetime = true,
                         ValidateAudience = false,
                         ValidateIssuer = false,
                         ClockSkew = TimeSpan.Zero
                     },
                     out securityToken
                    );
            }
            catch (SecurityTokenException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            return securityToken != null;
        }
    }
}
