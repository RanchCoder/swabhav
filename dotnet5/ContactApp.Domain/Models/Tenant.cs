using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Domain.Models
{
    public class Tenant : BaseEntity
    {
        

        public string CompanyName { get; set; }
        public long CompanyStrength { get; set; }
       
        public virtual List<User> Users { get; set; }
    }
}
