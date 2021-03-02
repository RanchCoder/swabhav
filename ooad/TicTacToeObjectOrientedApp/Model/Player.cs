using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeObjectOrientedApp.Model
{
    public class Player
    {
        private string name;
        private EnumForMarks.Mark mark;

        public Player(string name,EnumForMarks.Mark mark)
        {
            this.name = name;
            this.mark = mark;
        }

        public string Name { get => name; set => name = value; }
        public EnumForMarks.Mark MarkOfPlayer { get => mark; set => mark = value; }



    }
}
