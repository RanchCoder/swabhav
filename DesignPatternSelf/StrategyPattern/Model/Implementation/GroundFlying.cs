using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model.Behaviors;


namespace StrategyPattern.Model.Implementation
{
    class GroundFlying : IFlyBehavior
    {
        void IFlyBehavior.Fly()
        {
            Console.WriteLine($"This Duck flying while staying close to ground...");
        }
    }
}
