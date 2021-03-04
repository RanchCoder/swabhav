using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model.MobileBrand
{
    class OnePlus : IMobileManufacturer
    {
        public string CompanyDetails()
        {
            return MobileEnumeration.BRAND.ONEPLUS.ToString();
        }
    }
}
