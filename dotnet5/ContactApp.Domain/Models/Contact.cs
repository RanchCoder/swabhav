using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ContactApp.Domain.Models
{
    public class Contact
    {
        public Contact()
        {
            Addresses =  new List<Address>();
        }
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public long PhoneNumber { get; set; }


        public virtual List<Address> Addresses { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
