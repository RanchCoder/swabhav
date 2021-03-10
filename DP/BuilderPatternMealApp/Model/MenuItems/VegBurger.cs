using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model.MenuItems
{
    class VegBurger : Burger
    {

        const float PRICE_OF_VEG_BURGER = 250.35f;
        public override string Name()
        {
            return "Veg Panner ticka Burger";
        }

        public override float Price()
        {
            return PRICE_OF_VEG_BURGER;
        }
    }
}
