using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.DTO
{
    public class TokenDTO
    {
        public Guid Token { get; set; }
        public string CompanyName { get; set; }
    }
}
