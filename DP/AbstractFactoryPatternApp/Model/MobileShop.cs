using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    class MobileShop
    {
        IMobileFactory mobileFactory;
        public IMobileFactory BuyMobile(string mobileCompany)
        {
            if (mobileCompany.ToUpper().Equals(MobileEnumeration.BRAND.APPLE.ToString()))
            {
                return new AppleMobileFactory();
            }else if (mobileCompany.ToUpper().Equals(MobileEnumeration.BRAND.LENOVO.ToString()))
            {
                return new LenovoMobileFactory();
            }
            else if(mobileCompany.ToUpper().Equals(MobileEnumeration.BRAND.ONEPLUS.ToString()))
            {
                return new OnePlusMobileFactory();
            }
            else
            {
                throw new NoSuchMobileExcpetion();
            }
        }


    }
}
