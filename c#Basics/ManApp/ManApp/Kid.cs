using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManApp
{
    class Kid : Man
    {
        public override void Plays()
        {
            Console.WriteLine($"Kids Play");
        }
    }
}
