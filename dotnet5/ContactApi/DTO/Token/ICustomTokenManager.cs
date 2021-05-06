using ContactApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Token
{
    public interface ICustomTokenManager
    {
        string CreateSuperAdminToken(SuperAdmin user);
        string CreateToken(User user);
        string GetUserInfoByToken(string token);
        bool VerifyToken(string token);
    }
}
