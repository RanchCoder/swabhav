using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityApp.RequestHandler
{
    class HotelA : FoodServiceRequestHandler
    {
        private List<DishName> _dishList = new List<DishName>() {
           DishName.Aloo_mutter,
           DishName.Paneer_kolhapuri
        };
        public HotelA(HotelType hotelType)
        {
            this.hotelType = hotelType;
        }
        public override void ServeDish(DishName dishName)
        {
            
            if (_dishList.Contains(dishName))
            {
                Console.WriteLine("Dish order is available, it will be delivered in 34 mins");
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
