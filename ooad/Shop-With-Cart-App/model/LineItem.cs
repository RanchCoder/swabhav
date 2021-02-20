using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    public class LineItem
    {
        private Guid _idOfLineItem;
        private int _itemQuantity;
        private Product _product;

        public LineItem(Guid idOfLineItem, int itemQuantity, Product product)
        {
            this._idOfLineItem = idOfLineItem;
            this._itemQuantity = itemQuantity;
            this._product = product;
        }

        public Guid IdOfLineItem { get => _idOfLineItem;  }
        public int ItemQuantity { get => _itemQuantity; set => _itemQuantity = value; }
        internal Product GetProduct { get => _product; }

        public double CalculateItemCost()
        {
            return this._product.TotalCost() * ItemQuantity;
        }

        public override string ToString()
        {
            return $"\n\nId of Item : {IdOfLineItem} ||\nProduct Details : {_product.ToString()} ||\nQuantity : {ItemQuantity}";
        }
    }
}
