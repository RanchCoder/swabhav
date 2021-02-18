using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowRoom_App.model;
namespace CarShowRoom_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Car carModel1 = new Car("baleno","suzuki",4,"XUV",400000f);
            Car carModel2 = new Car("City","Honda",4,"XUV",550000f);
            SortedSet<Car> listOfCarsInShowroom = new SortedSet<Car>();
            listOfCarsInShowroom.Add(carModel1);
            listOfCarsInShowroom.Add(carModel2);
            CarShowroom carShowRoomInstance = new CarShowroom("Wasan Motors","Mumbai","Alex ceaser",listOfCarsInShowroom);
            PrintCarShowRoomDetails(carShowRoomInstance);
            Console.ReadLine();
        }

        public static void PrintCarShowRoomDetails(CarShowroom carShowRoomInstance)
        {
            Console.WriteLine($"Welcome to {carShowRoomInstance.CarShowRoomName}" +
                              $"\nLocation : {carShowRoomInstance.CarShowRoomAddress}" +
                              $"\nOwner : {carShowRoomInstance.CarShowRoomOwnerName}");

            Console.WriteLine($"+++++++++Car Catalogue++++++++");
            foreach(Car car in carShowRoomInstance.CarListInShowRoom)
            {
                Console.WriteLine($"\nCar Model Name : {car.CarModelName}" +
                                  $"\nCar Company Name : {car.CarCompanyName}" +
                                  $"\nNumber of Seater : {car.NumberOfSeaters} seater" +
                                  $"\nType of Car : {car.CarType}" +
                                  $"\nPrice of Car : Rs.{car.PriceOfCar}/-");
            }
        }
    }
}
