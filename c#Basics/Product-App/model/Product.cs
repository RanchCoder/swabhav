using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_App.model
{
    class Product
    {
        private int id;
        private String name;
        private double unitPrice;
        private int quantity;

        public Product(int id, String name, double unitPrice, int quantity)
        {
            this.id = id;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }

       
    }
}
