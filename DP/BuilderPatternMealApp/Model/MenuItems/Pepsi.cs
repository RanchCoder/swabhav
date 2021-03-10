using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model.MenuItems
{
    class Pepsi : ColdDrink
    {
        const float PRICE_OF_PEPSI = 100.5f;
        public override string Name()
        {
            return "Pepsi";
        }

        public override float Price()
        {
            return PRICE_OF_PEPSI;
        }
    }
}
