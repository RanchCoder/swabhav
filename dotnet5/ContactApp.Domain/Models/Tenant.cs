using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Domain.Models
{
    public class Tenant
    {
        [Key]
        public Guid TenantId { get; set; }
        public string TenantName { get; set; }


        public virtual List<User> Users { get; set; }
    }
}
