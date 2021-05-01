using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.DTO
{
    public class CountDTO
    {
      
        public int UserCount { get; set; }
        public int ContactCount { get; set; }

        public int AddressCount { get; set; }

        public long CompanyStrength { get; set; }
    }
}
