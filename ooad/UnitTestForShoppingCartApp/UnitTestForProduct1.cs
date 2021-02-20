using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shop_With_Cart_App.model;

namespace UnitTestForShoppingCartApp
{
    [TestClass]
    public class UnitTestForProduct1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double discount = 0.1;
            double priceForTesting = 15;


            Product product1 = new Product(Guid.NewGuid(), "Maggie", 15, 0.1);

            double priceAfterDiscount = product1.TotalCost();


            double expectedPrice = priceForTesting - (priceForTesting * discount);

            //assert 
            Assert.AreEqual(expectedPrice, product1.TotalCost());

        }
    }

}



