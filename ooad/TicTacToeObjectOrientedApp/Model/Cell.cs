using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeObjectOrientedApp.CustomExceptions;

namespace TicTacToeObjectOrientedApp.Model
{
    public class Cell
    {
        EnumForMarks.Mark mark;
        public void SetMark(EnumForMarks.Mark mark)
        {
            this.mark = mark;
        }

        public string[] IsCellEmpty(string[] board,int location)
        {
            if (!board[location].Equals("-"))
            {
                throw new CellAlreadyOccupiedException();
            }
            else
            {
                board[location] = mark.ToString();
                return board;
            }
        }
    }

}

