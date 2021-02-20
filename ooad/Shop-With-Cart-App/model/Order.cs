using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    public class Order
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
            if (itemsListForOrder.Equals(null))
            {
                itemsListForOrder.Add(item);
            }
            else
            {
                foreach(LineItem productItem in itemsListForOrder)
                {
                    if (productItem.GetProduct.Equals(item.GetProduct))
                    {
                        productItem.ItemQuantity += item.ItemQuantity;
                        isAdded = true;
                    }
                }
                if (!isAdded)
                {
                    itemsListForOrder.Add(item);
                }
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
            return $"\n Date of Order : {DateOfOrder} ||\nOrder Items : {string.Join( ",", itemsListForOrder)} || \nFinal Cost : {FinalCost()}";
        }

    }
}
