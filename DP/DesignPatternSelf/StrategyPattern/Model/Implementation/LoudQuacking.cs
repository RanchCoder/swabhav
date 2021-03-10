using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model.Behaviors;
namespace StrategyPattern.Model.Implementation
{
    class LoudQuacking : IQuackBehavior
    {
        void IQuackBehavior.Quack()
        {
           Console.WriteLine("This Duck quacks loudly QUACK, QUACK, QUACK!!!");
        }
    }
}
