using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeObjectOrientedApp.Model
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private Board board;
        private ResultAnalyzer analyzeResult;
        private int CURRENT_PLAYER = 0, NEXT_PLAYER = 1;
        private int flag = 0;

        public Game(List<Player> players, Board board, ResultAnalyzer analyzeResult)
        {
            this.players = players;
            this.board = board;
            this.analyzeResult = analyzeResult;
        }

        public Board Board { get => board; set => board = value; }
        internal List<Player> Players { get => players; set => players = value; }
        internal ResultAnalyzer AnalyzeResult { get => analyzeResult; set => analyzeResult = value; }

        public bool Play(int location)
        {
            try
            {
                if (board.AddMarkToCell(GetCurrentPlayer().MarkOfPlayer, location))
                {
                    board.PrintBoard();
                    if (flag == 0)
                    {
                        CURRENT_PLAYER++;
                        NEXT_PLAYER--;
                        flag++;
                    }
                    else
                    {
                        CURRENT_PLAYER--;
                        NEXT_PLAYER++;
                        flag--;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        
        public Player GetCurrentPlayer()
        {
            return players.ElementAt(CURRENT_PLAYER);
        }
        
        public Player GetNextPlayer()
        {
            return players.ElementAt(NEXT_PLAYER);
        }

        public string GetStatus()
        {
            return analyzeResult.CheckWinner();
        }
    }
}
