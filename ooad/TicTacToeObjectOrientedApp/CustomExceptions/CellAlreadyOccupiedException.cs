using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeObjectOrientedApp.CustomExceptions
{
    class CellAlreadyOccupiedException : Exception
    {
        public CellAlreadyOccupiedException() : base("cell already occupied") { }
    }
}
