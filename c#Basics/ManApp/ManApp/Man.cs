using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManApp
{
    class Man
    {
        public virtual void Plays()
        {
            Console.WriteLine($"Man Plays");
        }
        public void Read()
        {
            Console.WriteLine($"Man Reads Book");
        }
    }
}
