using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    interface IMobileFactory
    {
        IMobileOS GetMobileOS();
        IMobileManufacturer GetMobileManufacturer();

        
    }
}
