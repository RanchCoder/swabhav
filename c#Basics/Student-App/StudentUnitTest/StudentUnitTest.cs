using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Student_App.model;
namespace StudentUnitTest
{
    [TestClass]
    public class StudentUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Student s = new Student();

            string expectedName = "Vishala";
            int expectedId = 1;
            float expectedCreditPoint = 4.8f;

            //apply
            s.SetName("Vishal");
            s.SetId(1);
            s.SetCreditPoint(4.8f);



            //assert
            Assert.AreEqual(expectedName,s.GetName());
            Assert.AreEqual(expectedId,s.GetId());
            Assert.AreEqual(expectedCreditPoint,s.GetCreditPoint());


        }
    }
}
