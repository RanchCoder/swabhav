using System;
using System.Collections.Generic;
using System.Text;
namespace ChainOfResponsibilityApp.RequestSender
{
    public class Client
    {
        private HotelType _hotelType;
        private DishName _dishName;
        public Client(HotelType hotelType,DishName dishName)
        {
            this._hotelType = hotelType;
            this._dishName = dishName; 
        }

        public HotelType HotelType { get => _hotelType; set => _hotelType = value; }
        public DishName DishName { get => _dishName; set => _dishName = value; }
    }
}
