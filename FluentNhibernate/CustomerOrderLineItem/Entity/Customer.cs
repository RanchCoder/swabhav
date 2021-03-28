using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderLineItem.Entity
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<Order> Orders { get; set; } = new List<Order>();

        public virtual void AddOrderForCustomer(Order order)
        {
            order.Customer = this;
            Orders.Add(order);
        }
    }
}
