using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    public class MobileEnumeration
    {
        public enum OS
        {
            MAC,
            WINDOWS,
            LINUX
        } 

        public enum BRAND
        {
            APPLE,
            LENOVO,
            ONEPLUS
        }
    }
}
