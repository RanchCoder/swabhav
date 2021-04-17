using System;
using ChainOfResponsibilityApp.RequestHandler;
using ChainOfResponsibilityApp.RequestSender;

namespace ChainOfResponsibilityApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Program foodDeliveryApp = new Program();
            
            FoodServiceRequestHandler requesHandler = foodDeliveryApp.GetChainOfHotels();
            Client customer1 = new Client(HotelType.VEG,DishName.Dosa);
            requesHandler.TakeOrder(customer1);
            Console.ReadLine();
        }
        public FoodServiceRequestHandler GetChainOfHotels()
        {
            FoodServiceRequestHandler hotelA = new HotelA(HotelType.VEG);

            FoodServiceRequestHandler hotelB = new HotelB(HotelType.VEG);

            FoodServiceRequestHandler hotelC = new HotelB(HotelType.NON_VEG);

            hotelA.SetNextHandler(hotelB);
            hotelB.SetNextHandler(hotelC);
            return hotelA;
        }
    }

   

}
