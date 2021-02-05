using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Behaviour_App
{
    class Parent
    {
        private int foo;
        

        public Parent(int foo)
        {
            this.foo = foo;
            Console.WriteLine(this.foo);
        }

        public int GetValue()
        {
            return this.foo;
        }
        
    }
}
