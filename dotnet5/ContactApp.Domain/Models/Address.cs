using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactApp.Domain.Models
{
    public class Address : BaseEntity
    {

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Guid ContactID {get; set;}

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Contact Contact { get; set; }

}
}
