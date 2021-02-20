using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    class Customer
    {
        private Guid idOfCustomer;
        private string nameOfCustomer;
        private string addressOfCustomer;
        private List<Order> ordersByCustomer = new List<Order>();
        public Customer(Guid idOfCustomer, string nameOfCustomer, string addressOfCustomer)
        {
            this.idOfCustomer = idOfCustomer;
            this.nameOfCustomer = nameOfCustomer;
            this.addressOfCustomer = addressOfCustomer;
        }

        public Guid Id { get => idOfCustomer; set => idOfCustomer = value; }
        public string NameOfCustomer { get => nameOfCustomer; set => nameOfCustomer = value; }
        public string AddressOfCustomer { get => addressOfCustomer; set => addressOfCustomer = value; }

        public void AddOrder(Order order)
        {
            ordersByCustomer.Add(order);
        }
    }
}
