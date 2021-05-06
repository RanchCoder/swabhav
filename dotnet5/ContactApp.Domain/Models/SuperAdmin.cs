using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Domain.Models
{
    public class SuperAdmin : BaseEntity
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
