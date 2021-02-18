using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Employee_App;


namespace UnitTestEmployeeApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            float bonus = 0.2f;
            Programmer p = new Programmer(1,"vishal",15000,new DateTime(1998,11,23));
            float salary = p.Salary;

            float expectedFinalSalary = salary + (salary * bonus);

            Assert.AreEqual(expectedFinalSalary,p.ProgrammerSalaryWithBonus());

        }

        [TestMethod]
        public void TestMethod2()
        {
            
            Programmer p = new Programmer(1, "vishal", 15000, new DateTime(1998, 11, 23));
            

            DateTime expectedDateOfBirth = new DateTime(1997,11,23);

            Assert.AreEqual(expectedDateOfBirth, p.Date);

        }
    }
}
