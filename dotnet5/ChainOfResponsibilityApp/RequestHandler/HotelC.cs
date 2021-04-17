using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityApp.RequestHandler
{
    class HotelC : FoodServiceRequestHandler
    {
        private List<DishName> _dishList = new List<DishName>() {
           DishName.Mutton_pulav,
           DishName.Butter_chicken
        };
        public HotelC(HotelType hotelType)
        {
            this.hotelType = hotelType;
        }
        public override void ServeDish(DishName dishName)
        {
            if (_dishList.Contains(dishName))
            {
                Console.WriteLine("Dish order is recieved, it will be delivered in 34 mins");
            }
            else
            {
                if (this.nextRequestHandler != null)
                {
                    this.nextRequestHandler.ServeDish(dishName);

                }
            }
        }
    }
}
