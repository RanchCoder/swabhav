using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model.Behaviors;

namespace StrategyPattern.Model.Implementation
{
    class NoQuacking : IQuackBehavior
    {
        void IQuackBehavior.Quack()
        {
            Console.WriteLine("This Duck does not quacks!!!");
        }
    }

}
