using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    class Customer
    {
        private Guid _idOfCustomer;
        private string _nameOfCustomer;
        private string _addressOfCustomer;
        private List<Order> _ordersByCustomer = new List<Order>();
        public Customer(Guid idOfCustomer, string nameOfCustomer, string addressOfCustomer)
        {
            this._idOfCustomer = idOfCustomer;
            this._nameOfCustomer = nameOfCustomer;
            this._addressOfCustomer = addressOfCustomer;
        }

        public Guid Id { get => _idOfCustomer; }
        public string NameOfCustomer { get => _nameOfCustomer; }
        public string AddressOfCustomer { get => _addressOfCustomer;}
        internal List<Order> OrdersByCustomer { get => _ordersByCustomer; set => _ordersByCustomer = value; }

        public void AddOrder(Order order)
        {
            _ordersByCustomer.Add(order);
        }
    }
}
