using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    class Product
    {
        private Guid idOfProduct;
        private string nameOfProduct;
        private double priceOfProduct;
        private double discountPercent;

        public Product(Guid idOfProduct, string nameOfProduct, double priceOfProduct, double discountPercent)
        {
            this.idOfProduct = idOfProduct;
            this.nameOfProduct = nameOfProduct;
            this.priceOfProduct = priceOfProduct;
            this.discountPercent = discountPercent;
        }

        public Guid IdOfProduct { get => idOfProduct; set => idOfProduct = value; }
        public string NameOfProduct { get => nameOfProduct; set => nameOfProduct = value; }
        public double PriceOfProduct { get => priceOfProduct; set => priceOfProduct = value; }
        public double DiscountPercent { get => discountPercent; set => discountPercent = value; }

        public double TotalCost()
        {
            return priceOfProduct - (priceOfProduct * discountPercent);
        }
    }
}
