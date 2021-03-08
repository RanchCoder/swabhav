using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerApp.Model
{
    class Car
    {
        private string _carName;

        public Car(string carName)
        {
            _carName = carName;
        }

        public string CarName { get => _carName; set => _carName = value; }
    }
}
