using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicTacToeObjectOrientedApp.Model;

namespace UnitTestingForTicTacToe
{
    [TestClass]
    public class UnitTestForBoard
    {
        [TestMethod]
        public void TestForSize()
        {
            int testSizeForBoard = 3;

            Board b = new Board(3);
            int resultSize = b.GetSize();

            int expectedSizeForBoard = 3;

            Assert.AreEqual(expectedSizeForBoard, resultSize);
        }

        [TestMethod]
        public void TestForCellData()
        {
            int testSizeForBoard = 3;
            Cell c = new Cell();

            Board b = new Board(3);

            b.CreateBoard();
            string[] board = b.GetBoard();
            c.SetMark(EnumForMarks.Mark.X);

            board = c.IsCellEmpty(board,0);

            string resultString = board[0];
            string expectedData = EnumForMarks.Mark.X.ToString();

            Assert.AreEqual(expectedData,resultString);

        }

        [TestMethod]
        public void TestForBoardCapacity()
        {
            int testSizeForBoard = 3;
            Cell c = new Cell();

            Board b = new Board(3);
            b.CreateBoard();
            string[] board = b.GetBoard();
            c.SetMark(EnumForMarks.Mark.X);

            board = c.IsCellEmpty(board, 0);
            bool result = b.IsBoardFull();

            bool expectedResult = false;
           
            Assert.AreEqual(expectedResult,result);

        }


        [TestMethod]
        public void TestForBoardMarkAtParticularLocation()
        {
            int testSizeForBoard = 3;
            Cell c = new Cell();

            Board b = new Board(3);
            b.CreateBoard();
            b.AddMarkToCell(EnumForMarks.Mark.X,0);
            string[] board = b.GetBoard();
            string actualResult = board[0];
            string markExpected = "X";

            Assert.AreEqual(markExpected, actualResult);

        }

    }
}
