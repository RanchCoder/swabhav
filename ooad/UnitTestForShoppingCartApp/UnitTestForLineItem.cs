using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shop_With_Cart_App.model;

namespace UnitTestForShoppingCartApp
{
    [TestClass]
    public class UnitTestForLineItem
    {
        [TestMethod]
        public void TestMethod1()
        {

            Product product = new Product(Guid.NewGuid(),"Glassware",1000,0.1);
            LineItem itemForCart = new LineItem(Guid.NewGuid(),10,product);
            int quantity = 10;
            double price = 1000;
            double discount = 0.1;
            double priceAfterDiscont = price - (price * discount);
            double expectedPrice = priceAfterDiscont * quantity;
            Assert.AreEqual(expectedPrice,itemForCart.CalculateItemCost());
        }
    }
}
