using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAddressMVCApp.ViewModels
{
    public class ViewAllAddressesVM
    {
        public virtual int Id { get; set; }
        public virtual string Location { get; set; }
        public virtual int ContactId { get; set; }

    }
}