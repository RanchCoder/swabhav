using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePatternApp.Model
{
    class Football : Game
    {
        public override void EndPlay()
        {
            Console.WriteLine($"Game of Football ends after 90mins gameplay.");
        }

        public override void Initialize()
        {
            Console.WriteLine($"Game of of football is initialized by adding 9 players in each team.");
        }

        public override void StartPlay()
        {
            Console.WriteLine($"The game of football is started when refree blows in first wistle on the football ground");
        }
    }
}
