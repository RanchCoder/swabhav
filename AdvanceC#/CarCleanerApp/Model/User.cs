using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerApp.Model
{
    class User
    {
        private string _username;
        List<Car> carList = new List<Car>();

        public User(string username)
        {
            _username = username;
        }

        public string Username { get => _username; set => _username = value; }

        public void AddCarToList(Car car)
        {
            if (!carList.Contains(car))
            {
                carList.Add(car);
            }
        }

        public List<Car> ShowUsersCarList()
        {
            return carList;
        }
    }
}
