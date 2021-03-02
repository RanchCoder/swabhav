using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePatternApp.Model
{
    class Cricket : Game
    {
        public override void EndPlay()
        {
            Console.WriteLine($"Game of cricket ends when one of the team wins the match.");
        }

        public override void Initialize()
        {
            Console.WriteLine($"Game of Cricket is Initialize by sorting 11 players in each team.");
        }

        public override void StartPlay()
        {
            Console.WriteLine($"The game of Cricket begins after the TOSS..");
        }
    }
}
