using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManApp
{
    class Boy : Man
    {
        public override void Plays()
        {
            Console.WriteLine($"Boy Plays");
        }

        public void Eats()
        {
            Console.WriteLine($"Boy eats");
        }
    }
}
