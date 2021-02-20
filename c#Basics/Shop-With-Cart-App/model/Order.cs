using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    class Order
    {
        private Guid idOfOrder;
        private DateTime dateOfOrder;
        private List<LineItem> itemsListForOrder = new List<LineItem>();

        public Order(Guid idOfOrder, DateTime dateOfOrder)
        {
            this.idOfOrder = idOfOrder;
            this.dateOfOrder = dateOfOrder;
        }

        public Guid Id { get => idOfOrder; set => idOfOrder = value; }
        public DateTime DateOfOrder { get => dateOfOrder; set => dateOfOrder = value; }
        internal List<LineItem> ItemsListForOrder { get => itemsListForOrder; set => itemsListForOrder = value; }

        public void AddItem(LineItem item)
        {
            itemsListForOrder.Add(item);
        }

        public double FinalCost()
        {
            double finalCost = 0;
            foreach(LineItem item in itemsListForOrder)
            {
                finalCost += item.CalculateItemCost();
            }
            return finalCost;
        }

        
    }
}
