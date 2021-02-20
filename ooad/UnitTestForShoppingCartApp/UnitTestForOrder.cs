using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shop_With_Cart_App.model;

namespace UnitTestForShoppingCartApp
{
    [TestClass]
    public class UnitTestForOrder
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product product1 = new Product(Guid.NewGuid(),"Maggie",15,0.1);
            
            LineItem lineItem = new LineItem(Guid.NewGuid(),5,product1);
            LineItem lineItem2 = new LineItem(Guid.NewGuid(), 5, product1);
            Order orderFromCustomer = new Order(Guid.NewGuid(),DateTime.Now);
            
            //act
            orderFromCustomer.AddItem(lineItem);
            orderFromCustomer.AddItem(lineItem2);

            
            
            int expectedQuantity = 10;

            //assert 
            Assert.AreEqual(expectedQuantity,lineItem.ItemQuantity);

        }


    }
}
