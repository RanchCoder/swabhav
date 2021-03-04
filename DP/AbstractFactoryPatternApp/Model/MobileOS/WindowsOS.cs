using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    public class WindowsOS : IMobileOS
    {
        public string OSDetails()
        {
            return MobileEnumeration.OS.WINDOWS.ToString();
        }
    }
}
