using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Model;
using StrategyPattern.Model.Implementation;
namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck jungleDuck = new WildDuck(new DisplayingGraphically(),new HighFlying(),new LoudQuacking());
            jungleDuck.Fly();
            jungleDuck.Display();
            jungleDuck.Quack();
            Console.ReadLine();
        }
    }
}
