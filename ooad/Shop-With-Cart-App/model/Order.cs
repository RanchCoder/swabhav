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

        public Guid Id { get => idOfOrder; }
        public DateTime DateOfOrder { get => dateOfOrder;}
        internal List<LineItem> ItemsListForOrder { get => itemsListForOrder; }

        public void AddItem(LineItem item)
        {
            bool isAdded = false;
            if(itemsListForOrder.Count > 0)
            {
                foreach(LineItem itemProduct in ItemsListForOrder)
                {
                    if (itemProduct.Equals(item))
                    {
                        itemProduct.ItemQuantity += item.ItemQuantity;
                        isAdded = true;
                        return;
                    }
                }
            }
            else
            {
                itemsListForOrder.Add(item);
            }
            
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

        public override string ToString()
        {
            return $"\n\n\t Date of Order : {DateOfOrder} || Order Items : {itemsListForOrder}";
        }

    }
}
