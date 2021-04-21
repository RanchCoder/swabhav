using FacadePatternApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternApp.FacadeShoppingApp
{
    class MobileInventory : IInventoryList
    {
        private List<InventoryItem> _mobileInventory = new List<InventoryItem>() {
         new InventoryItem(){Id = 1,Name="Galaxy s5",Price = 15000},
         new InventoryItem(){Id=2,Name="Iphone 7",Price=54000},
         new InventoryItem(){Id=3,Name="Blackberry",Price=30000}
        };
        public List<InventoryItem> GetInventoryList()
        {
            return _mobileInventory;
        }
    }
}
