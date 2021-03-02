using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeObjectOrientedApp.CustomExceptions;
namespace TicTacToeObjectOrientedApp.Model
{
    public class Board
    {
        private string[] board;
        private int size;
        private Cell cell;
        public Board(int size) {

            this.size = size;
            cell = new Cell();
        }

        public string[] GetBoard()
        {
            return board;
        }

        public Cell GetCell()
        {
            return cell;
        }

        public int GetSize()
        {
            return size;
        }

        public void CreateBoard()
        {
            board = new string[size * size];
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = "-";
            }
        }

        public bool IsBoardFull()
        {
            for(int i = 0; i < board.Length; i++)
            {
                if (board[i].Equals("-"))
                {
                    return false;
                }
            }
            return true;
        }

        public void PrintBoard()
        {
            int j = 1;
            for(int i = 0; i < board.Length; i++)
            {
                if(j <= size)
                {
                    Console.Write("| "+board[i]+ " ");
                    j++;
                }
                else
                {
                    j = 2;
                    Console.WriteLine("|");
                    Console.Write("| "+board[i] + " ");
                }
            }
            Console.WriteLine("|");
        }

        public bool AddMarkToCell(EnumForMarks.Mark mark,int location) { 
         
            if(location > board.Length - 1)
            {
                throw new OutOfCellException();
            }
            if (!IsBoardFull())
            {

                cell.SetMark(mark);
                board = cell.IsCellEmpty(board, location);
                return true;
            }
            return false;
        
        }
    }
}
