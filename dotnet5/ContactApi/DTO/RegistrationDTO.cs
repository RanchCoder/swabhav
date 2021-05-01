using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.DTO
{
    public class RegistrationDTO
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public long CompanyStrength { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string CompanyEmail { get; set; }
        
    }
}
