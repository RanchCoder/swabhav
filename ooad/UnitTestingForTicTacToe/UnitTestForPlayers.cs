using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicTacToeObjectOrientedApp.Model;
namespace UnitTestingForTicTacToe
{
    [TestClass]
    public class UnitTestForPlayers
    {
        [TestMethod]
        public void TestForPlayerName()
        {
            Player p1 = new Player("Vishal",EnumForMarks.Mark.X);

            string expectedName = "Vishal";
            string actualValue = p1.Name;

            Assert.AreEqual(expectedName,actualValue);
        }

        [TestMethod]
        public void TestForPlayerMark()
        {
            Player p1 = new Player("Vishal", EnumForMarks.Mark.X);

            string expectedMark = EnumForMarks.Mark.O.ToString();
            string actualValue = p1.MarkOfPlayer.ToString();

            Assert.AreEqual(expectedMark, actualValue);
        }
    }
}
