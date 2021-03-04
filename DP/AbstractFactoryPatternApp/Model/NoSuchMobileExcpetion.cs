using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    class NoSuchMobileExcpetion : Exception
    {
        public NoSuchMobileExcpetion() : base("No such mobile Exception") { }
    }
}
