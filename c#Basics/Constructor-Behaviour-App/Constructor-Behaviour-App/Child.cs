using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Behaviour_App
{
    class Child : Parent
    {
        private int foo;
        public Child(int foo):base(100)
        {
            this.foo = foo;
        }

        public int GetValue()
        {
            return this.foo;
        }
    }
}
