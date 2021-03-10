using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model.MenuItems
{
    public abstract class ColdDrink : Item
    {
        public abstract string Name();
        Packing Item.Packing()
        {
            return new Bottle();
        }
        public abstract float Price();
    }
}
