using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp.Model
{
    class Audi : IAutomobile
    {
        void IAutomobile.Start()
        {
            Console.WriteLine("Audi started");
        }

        void IAutomobile.Stop()
        {
            Console.WriteLine("Audi stopped");
        }
    }
}
