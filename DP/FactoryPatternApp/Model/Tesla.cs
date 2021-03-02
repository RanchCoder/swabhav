using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp.Model
{
    class Tesla : IAutomobile
    {
        void IAutomobile.Start()
        {
            Console.WriteLine("Tesla started");
        }

        void IAutomobile.Stop()
        {
            Console.WriteLine("Tesla stopped");
        }
    }
}
