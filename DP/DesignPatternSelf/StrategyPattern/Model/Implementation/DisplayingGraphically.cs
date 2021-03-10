using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model.Behaviors;
namespace StrategyPattern.Model.Implementation
{
    class DisplayingGraphically : IDisplayBehavior
    {
        void IDisplayBehavior.Display()
        {
            Console.WriteLine($"Displaying the duck is GRAPHICAL FORMAT.");
        }
    }
}
