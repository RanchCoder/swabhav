using ChainOfResponsibilityApp.RequestSender;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityApp.RequestHandler
{
    abstract class FoodServiceRequestHandler
    {
        protected HotelType hotelType;
        protected FoodServiceRequestHandler nextRequestHandler;

        public void SetNextHandler(FoodServiceRequestHandler requestHandler)
        {
            this.nextRequestHandler = requestHandler;
        }

        public void TakeOrder(Client client)
        {
            if (this.hotelType.Equals(client.HotelType))
            {
                ServeDish(client.DishName);
            }
            else if(nextRequestHandler != null)
            {
                nextRequestHandler.ServeDish(client.DishName);
            }
        }

        public abstract void ServeDish(DishName dishName);
    }
}
