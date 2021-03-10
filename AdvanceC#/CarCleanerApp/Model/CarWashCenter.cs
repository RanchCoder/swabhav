using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarCleanerApp.Model
{
    class CarWashCenter
    {
        private string _centerName;

        public delegate void CarWashEventHandler(User user,Car car);

        
        public event Action<User,Car> CarWashEvent;
        
        public CarWashCenter(string centerName)
        {
            _centerName = centerName;
        }

        public void WashCar(User user,Car car)
        {
            Console.WriteLine($"Washing car : {car.CarName}");
            Thread.Sleep(3000);
            OnCarWashed(user,car);
        }

        public void OnCarWashed(User user,Car car)
        {
            if(CarWashEvent != null)
            {
                CarWashEvent(user,car);
            }
            
        }
       
    }
}
