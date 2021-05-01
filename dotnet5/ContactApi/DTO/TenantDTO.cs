using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.DTO
{
    public class TenantDTO
    {
        [Required]
        public string CompanyName { get; set; }
        public long CompanyStrength { get; set; }
    }
}
