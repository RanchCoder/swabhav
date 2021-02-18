using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom_App.model
{
    class Car : IComparable
    {
        private string carModelName;
        private string carCompanyName;
        private int numberOfSeaters;
        private float priceOfCar;
        private string carType;

        public Car(string carModelName, string carCompanyName, int numberOfSeaters, string carType,float priceOfCar)
        {
            this.carModelName = carModelName;
            this.carCompanyName = carCompanyName;
            this.numberOfSeaters = numberOfSeaters;
            this.carType = carType;
            this.priceOfCar = priceOfCar;
        }

        public string CarModelName { get => carModelName; set => carModelName = value; }
        public string CarCompanyName { get => carCompanyName; set => carCompanyName = value; }
        public int NumberOfSeaters { get => numberOfSeaters; set => numberOfSeaters = value; }
        public string CarType { get => carType; set => carType = value; }
        public float PriceOfCar { get => priceOfCar; set => priceOfCar = value; }

        public int CompareTo(object obj)
        {
            Car carToBeCompared = (Car)obj;
            return carCompanyName.CompareTo(carToBeCompared.carCompanyName);
        }
    }
}
