using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    class LineItem
    {
        private Guid idOfLineItem;
        private int itemQuantity;
        private Product product;

        public LineItem(Guid idOfLineItem, int itemQuantity, Product product)
        {
            this.idOfLineItem = idOfLineItem;
            this.itemQuantity = itemQuantity;
            this.product = product;
        }

        public Guid IdOfLineItem { get => idOfLineItem; set => idOfLineItem = value; }
        public int ItemQuantity { get => itemQuantity; set => itemQuantity = value; }
        internal Product Product { get => product; set => product = value; }

        public double CalculateItemCost()
        {
            return this.product.TotalCost() * ItemQuantity;
        }
    }
}
