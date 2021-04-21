using FacadePatternApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternApp.FacadeShoppingApp
{
    class DressInventory : IInventoryList
    {
        private List<InventoryItem> _dressInventory = new List<InventoryItem>() {
         new InventoryItem(){Id = 1,Name="Denim Shirt",Price = 1500},
         new InventoryItem(){Id=2,Name="Tie",Price=450},
         new InventoryItem(){Id=3,Name="Pajama",Price=300}
        };
        public List<InventoryItem> GetInventoryList()
        {
            return _dressInventory;
        }
    }
}
