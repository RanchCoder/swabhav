using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TicTacToeObjectOrientedApp.Model;
namespace UnitTestingForTicTacToe
{
    [TestClass]
    public class UnitTestForGame
    {
        [TestMethod]
        public void TestMethodForCurrentPlayer()
        {
            Player p1 = new Player("Vishal",EnumForMarks.Mark.X);

            Player p2 = new Player("Prem", EnumForMarks.Mark.O);

            List<Player> players = new List<Player>();
            players.Add(p1);
            players.Add(p2);

            Board board = new Board(3);
            board.CreateBoard();
            Game gameInstance = new Game(players,board,new ResultAnalyzer(board));
            Player actualCurrentPlayer = gameInstance.GetCurrentPlayer();

            Player expectedPlayer = p1;

            Assert.AreEqual(actualCurrentPlayer,expectedPlayer);
        }

        [TestMethod]
        public void TestMethodForNextPlayer()
        {
            Player p1 = new Player("Vishal", EnumForMarks.Mark.X);

            Player p2 = new Player("Prem", EnumForMarks.Mark.O);

            List<Player> players = new List<Player>();
            players.Add(p1);
            players.Add(p2);

            Board board = new Board(3);
            board.CreateBoard();
            Game gameInstance = new Game(players, board, new ResultAnalyzer(board));
            Player actualCurrentPlayer = gameInstance.GetNextPlayer();

            Player expectedPlayer = p2;

            Assert.AreEqual(actualCurrentPlayer, expectedPlayer);
        }
    }
}
