using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicTacToeObjectOrientedApp.Model;

namespace UnitTestingForTicTacToe
{
    [TestClass]
    public class UnitTestForCell
    {
        [TestMethod]
        public void TestForMark()
        {
            Cell c = new Cell();
            c.SetMark(EnumForMarks.Mark.X);

            Board b = new Board(3);
            b.CreateBoard();
            string[] board = b.GetBoard();
            board = c.IsCellEmpty(board,0);
            string result = board[0];

            string expectedMark = EnumForMarks.Mark.O.ToString();

            Assert.AreEqual(expectedMark,result);
        }
    }
}
