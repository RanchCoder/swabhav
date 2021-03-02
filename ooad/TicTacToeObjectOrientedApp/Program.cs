using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeObjectOrientedApp.Model;

namespace TicTacToeObjectOrientedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            string p;
            int location;
            Console.Write("Enter Board Size : ");
            string s = Console.ReadLine();
            int size;
            Int32.TryParse(s,out size);

            Board board = new Board(size);
            board.CreateBoard();

            Game game = new Game(players,board,new ResultAnalyzer(board));
            string name = GetFirstDataFromUser(game, players);

            while (true)
            {
                Console.Write($"{name} enter cell number: ");
                location = Int32.Parse(Console.ReadLine());
                if (game.Play(location))
                {
                    break;
                }
            }

            name = GetFirstDataFromUser(game,players);
            while (true)
            {
                Console.Write($"{name} enter cell number: ");
                location = Int32.Parse(Console.ReadLine());
                if (game.Play(location))
                {
                    break;
                }
            }

            while (game.GetStatus().Equals("INPROGRESS"))
            {
                Console.WriteLine(game.GetCurrentPlayer().Name + " enter a cell number : ");
                location = Int32.Parse(Console.ReadLine());

                game.Play(location);
            }
            if (game.GetStatus().Equals("Win"))
            {
                Console.Write(game.GetNextPlayer().Name + " is WINNER!!");

            }else if (game.GetStatus().Equals("Draw"))
            {
                Console.WriteLine("It's a DRAW...");
            }

        }

        public static string GetFirstDataFromUser(Game game,List<Player> players)
        {
            Player player;
            string p;
            Console.Write($"Enter your name : ");
            p = Console.ReadLine();
            if(players.Count == 0)
            {
                player = new Player(p, EnumForMarks.Mark.X);
            }
            else
            {
                player = new Player(p,EnumForMarks.Mark.O);
            }
            players.Add(player);
            return p;
        }
    }
}
