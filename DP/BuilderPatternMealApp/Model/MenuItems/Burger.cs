using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model
{
    public abstract class Burger : Item
    {

        public abstract string Name();
        Packing Item.Packing()
        {
            return new Wrapper();
        }

        public abstract float Price();
    }
}
