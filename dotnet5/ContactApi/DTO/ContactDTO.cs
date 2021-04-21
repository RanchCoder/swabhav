using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.DTO
{
    public class ContactDTO
    {
        public Guid Id { get; set; }
       
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public long PhoneNumber { get; set; }


      
    }
}
