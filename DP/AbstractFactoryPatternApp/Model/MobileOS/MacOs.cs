﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp.Model
{
    class MacOs : IMobileOS
    {
        public string OSDetails()
        {
            return MobileEnumeration.OS.MAC.ToString();
        }
    }
}
