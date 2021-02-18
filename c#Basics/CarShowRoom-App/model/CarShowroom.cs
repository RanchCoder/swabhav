using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom_App.model
{
    class CarShowroom 
    {
        private string carShowRoomName;
        private string carShowRoomAddress;
        private string carShowRoomOwnerName;
        private SortedSet<Car> carListInShowRoom;

        public CarShowroom(string carShowRoomName, string carShowRoomAddress, string carShowRoomOwnerName,SortedSet<Car> carListInShowRoom)
        {
            this.carShowRoomName = carShowRoomName;
            this.carShowRoomAddress = carShowRoomAddress;
            this.carShowRoomOwnerName = carShowRoomOwnerName;
            this.carListInShowRoom = carListInShowRoom;
        }

        public string CarShowRoomName { get => carShowRoomName; set => carShowRoomName = value; }
        public string CarShowRoomAddress { get => carShowRoomAddress; set => carShowRoomAddress = value; }
        public string CarShowRoomOwnerName { get => carShowRoomOwnerName; set => carShowRoomOwnerName = value; }
        internal SortedSet<Car> CarListInShowRoom { get => carListInShowRoom; set => carListInShowRoom = value; }
    }
}
