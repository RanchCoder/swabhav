using FacadePatternApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternApp.FacadeShoppingApp
{
    class AmazonApp
    {

        private const int HardwareInventory = 1;
        private const int MobileInventory = 2;
        private const int DressInventory = 3;
        public List<InventoryItem> GetHardwareInventory()
        {
            HardwareInventory hardwareInventory = new HardwareInventory();
            return hardwareInventory.GetInventoryList();
        }

        public List<InventoryItem> GetMobileInventory()
        {
            MobileInventory mobileInventory = new MobileInventory();
            return mobileInventory.GetInventoryList();
        }

        public List<InventoryItem> GetDressInventory()
        {
            DressInventory dressInventory = new DressInventory();
            return dressInventory.GetInventoryList();
        }


        public List<InventoryItem> SpecifyRequirements()
        {
            Console.WriteLine("\n1.HARDWARE\n2.MOBILE\n3.DRESS");
            Console.Write("Enter the inventory number you wish to browse : ");
            int userChoice;
            int.TryParse(Console.ReadLine(), out userChoice);
            List<InventoryItem> itemList = new List<InventoryItem>();
            switch (userChoice)
            {
                case HardwareInventory:
                    itemList = GetHardwareInventory();
                    break;
                case MobileInventory:
                    itemList = GetMobileInventory();
                    break;
                case DressInventory:
                    itemList = GetDressInventory();
                    break;
                default:
                    Console.WriteLine("Please make a valid choice");
                    break;
            }
            return itemList;
        }
    }
}
