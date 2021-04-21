using FacadePatternApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternApp.FacadeShoppingApp
{
    interface IInventoryList
    {
        List<InventoryItem> GetInventoryList();
    }
}
