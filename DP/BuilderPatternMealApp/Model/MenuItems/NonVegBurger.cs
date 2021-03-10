using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model.MenuItems
{
    class NonVegBurger : Burger
    {

        const float PRICE_OF_NON_VEG_BURGER = 400.35f;
        public override string Name()
        {
            return "Chicken Burger";
        }

        public override float Price()
        {
            return PRICE_OF_NON_VEG_BURGER;
        }
    }
}
