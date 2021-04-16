using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactMVC.ViewModels
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ContactViewModel
    {
        [JsonProperty(PropertyName ="Id")]
        public virtual int Id { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public virtual string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public virtual string LastName { get; set; }

        [JsonProperty(PropertyName = "PhoneNo")]
        public virtual long PhoneNo { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public virtual string Address { get; set; }
    }
}