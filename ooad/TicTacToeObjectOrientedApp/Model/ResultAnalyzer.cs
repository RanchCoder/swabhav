using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeObjectOrientedApp.Model
{
    public class ResultAnalyzer
    {
        private Board board;
        private EnumForResult.Result result = EnumForResult.Result.INPROGRESS;

        public ResultAnalyzer(Board board)
        {
            this.board = board;
        }

        public string CheckWinner()
        {
            if (board.IsBoardFull())
            {
                return EnumForResult.Result.DRAW.ToString();
            }
            if (CheckRow().Equals(EnumForResult.Result.WIN))
            {
                return EnumForResult.Result.WIN.ToString();
            }
            if (CheckColumn().Equals(EnumForResult.Result.WIN))
            {
                return EnumForResult.Result.WIN.ToString();
            }
            if (CheckDiagonal().Equals(EnumForResult.Result.WIN))
            {
                return EnumForResult.Result.WIN.ToString();
            }

            return result.ToString();
        }

        public EnumForResult.Result CheckRow()
        {
            int j = 0, resultCount = 1;
            EnumForResult.Result result  = EnumForResult.Result.INPROGRESS;

            for(int i = 1; i < board.GetBoard().Length; i++)
            {
                if (!board.GetBoard()[j].Equals("-"))
                {
                    if(++resultCount == board.GetSize())
                    {
                        result = EnumForResult.Result.WIN;
                        break;
                    }
                }
            }
            return result;
        }

        public EnumForResult.Result CheckColumn()
        {
            EnumForResult.Result result = EnumForResult.Result.INPROGRESS;
            return result;
        }

        public EnumForResult.Result CheckDiagonal()
        {
            EnumForResult.Result result = EnumForResult.Result.INPROGRESS;
            return result;
        }


    }

}
