using CarCleanerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User userVishal = new User("vishal");
            Car hondaCity = new Car("Honda city");
            userVishal.AddCarToList(hondaCity);

            CarWashCenter wasanCarWashCenter = new CarWashCenter("Wasan car wash Center");
            wasanCarWashCenter.CarWashEvent += RecieveNotification;

            wasanCarWashCenter.WashCar(userVishal,hondaCity);

            Console.ReadLine();

        }

        public static void RecieveNotification(User user,Car car)
        {
            Console.WriteLine($"{user.Username} your car {car.CarName} was sent for wash." +
                $"\n Car wash service has been done." +
                $"\n You may collect your car from our center.");
        }
    }
}
