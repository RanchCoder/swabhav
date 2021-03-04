using AbstractFactoryPatternApp.Model.MobileBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    class OnePlusMobileFactory : IMobileFactory
    {
        public IMobileManufacturer GetMobileManufacturer()
        {
            return new OnePlus();
        }

        public IMobileOS GetMobileOS()
        {
            return new WindowsOS();
        }
    }
}
