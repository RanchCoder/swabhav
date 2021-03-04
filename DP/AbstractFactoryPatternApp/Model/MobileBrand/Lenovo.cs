using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model.MobileBrand
{
    class Lenovo : IMobileManufacturer
    {
        public string CompanyDetails()
        {
            return MobileEnumeration.BRAND.LENOVO.ToString();
        }
    }
}
