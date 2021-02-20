using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Model
{
    class Invoice
    {
        private int _id;
        private string _name;
        private double _discount;
        private double _gst;
        private double _amount;

        public Invoice(int id, string name, double discount, double gst, double amount)
        {
            _id = id;
            _name = name;
            _discount = discount;
            _gst = gst;
            _amount = amount;
        }

        public int Id { get => _id; }
        public string Name { get => _name;  }
        public double Discount { get => _discount;  }
        public double Gst { get => _gst;  }
        public double Amount { get => _amount;}


        public double ComputeDiscount()
        {
            return _amount * Discount;
        }

        public double ComputeGst()
        {
            return _amount * Gst;
        }

        public double CalculateTotalCost()
        {
            return (_amount - ComputeDiscount()) + ComputeGst();
        }
    }
}
