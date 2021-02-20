using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_With_Cart_App.model
{
    class Product
    {
        private Guid _idOfProduct;
        private string _nameOfProduct;
        private double _priceOfProduct;
        private double _discountPercent;

        public Product(Guid idOfProduct, string nameOfProduct, double priceOfProduct, double discountPercent)
        {
            this._idOfProduct = idOfProduct;
            this._nameOfProduct = nameOfProduct;
            this._priceOfProduct = priceOfProduct;
            this._discountPercent = discountPercent;
        }

        public Guid IdOfProduct { get => _idOfProduct; }
        public string NameOfProduct { get => _nameOfProduct;}
        public double PriceOfProduct { get => _priceOfProduct; }
        public double DiscountPercent { get => _discountPercent;}

        public double TotalCost()
        {
            return _priceOfProduct - (_priceOfProduct * _discountPercent);
        }

        public override string ToString()
        {
            return $"\n\tProuct Name : {this.NameOfProduct} || Product Price : {this.PriceOfProduct} || Discount : {this.DiscountPercent}";
        }
    }
}
