using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityApp.RequestHandler
{
    class HotelB : FoodServiceRequestHandler
    {
        private List<DishName> _dishList = new List<DishName>() {
           DishName.Dosa,
           DishName.Idli
        };
        public HotelB(HotelType hotelType)
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
                if(this.nextRequestHandler != null)
                {
                    this.nextRequestHandler.ServeDish(dishName);

                }
            }
        }
    }
}
