using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model.MenuItems
{
    class CocaCola : ColdDrink
    {
        const float PRICE_OF_COKE = 95.5f;
        public override string Name()
        {
            return "Coca Cola";
        }

        public override float Price()
        {
            return PRICE_OF_COKE;
        }
    }
}
