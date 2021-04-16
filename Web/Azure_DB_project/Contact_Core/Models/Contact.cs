using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Core.Models
{
    public class Contact
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual long PhoneNo { get; set; }
        public virtual string Address { get; set; }
    }
}
