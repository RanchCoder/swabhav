using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model.Behaviors;
namespace StrategyPattern.Model
{
    class Duck
    {
        IDisplayBehavior displayFormatOfDuck;
        IFlyBehavior flyingFormatOfDuck;
        IQuackBehavior quackingBehaviorOfDuck;

        public Duck(IDisplayBehavior displayFormatOfDuck, IFlyBehavior flyingFormatOfDuck, IQuackBehavior quackingBehaviorOfDuck)
        {
            this.displayFormatOfDuck = displayFormatOfDuck;
            this.flyingFormatOfDuck = flyingFormatOfDuck;
            this.quackingBehaviorOfDuck = quackingBehaviorOfDuck;
        }

        public void Fly()
        {
            flyingFormatOfDuck.Fly();
        }

        public void Quack()
        {
            quackingBehaviorOfDuck.Quack();
        }

        public void Display()
        {
            displayFormatOfDuck.Display();
        }
    }
}
