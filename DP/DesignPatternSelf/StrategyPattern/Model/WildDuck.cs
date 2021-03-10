using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model.Behaviors;
namespace StrategyPattern.Model
{
    class WildDuck : Duck
    {
        public WildDuck(IDisplayBehavior displayBehavior, IFlyBehavior flyBehavior, IQuackBehavior quackBehavior) :
            base(displayBehavior,flyBehavior,quackBehavior){ }



    }
}
