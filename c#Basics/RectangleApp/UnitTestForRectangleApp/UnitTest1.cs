using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestForRectangleApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           int returnValueForAreaComputation =  RectangleApp.Program.Area(10,10);
            Assert.AreEqual(returnValueForAreaComputation,200);

        }
    }
}
