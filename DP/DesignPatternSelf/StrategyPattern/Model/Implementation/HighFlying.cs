using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StrategyPattern.Model.Behaviors;

namespace StrategyPattern.Model.Implementation
{
    class HighFlying : IFlyBehavior
    {
        void IFlyBehavior.Fly()
        {
            Console.WriteLine("\n\nThis DUCK flys high in the sky");
        }
    }
}
