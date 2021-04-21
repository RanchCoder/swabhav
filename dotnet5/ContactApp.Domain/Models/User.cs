using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContactApp.Domain.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
