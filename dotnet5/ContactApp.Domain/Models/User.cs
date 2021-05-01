using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContactApp.Domain.Models
{
    public class User : BaseEntity
    {
        
        public string Username { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
        
        public string Token { get; set; }
        [JsonIgnore]
        public virtual Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
