using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderLineItem.Entity
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<LineItem> LineItems { get; set; } = new List<LineItem>();

        public virtual void AddLineItemToOrder(LineItem item)
        {
            item.OrderList.Add(this);
            LineItems.Add(item);
        }
    }
}
