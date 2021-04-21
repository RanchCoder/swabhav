using FacadePatternApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternApp.FacadeShoppingApp
{
    class HardwareInventory : IInventoryList
    {
        private List<InventoryItem> _hardwareInventory = new List<InventoryItem>() {
         new InventoryItem(){Id = 1,Name="Nutbolt",Price = 15},
         new InventoryItem(){Id=2,Name="ScrewDriver",Price=150},
         new InventoryItem(){Id=3,Name="Hammer",Price=30}
        };
        public List<InventoryItem> GetInventoryList()
        {
            return _hardwareInventory;
        }
    }
}
