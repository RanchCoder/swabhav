using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeObjectOrientedApp.CustomExceptions
{
    class OutOfCellException : Exception
    {
        public OutOfCellException() : base("Not a valid cell to be filled") { }
    }
}
