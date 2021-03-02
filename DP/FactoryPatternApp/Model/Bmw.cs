using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp.Model
{
   
        class Bmw : IAutomobile
        {
            void IAutomobile.Start()
            {
                Console.WriteLine("Bmw started");
            }

            void IAutomobile.Stop()
            {
                Console.WriteLine("Bmw stopped");
            }
        }
    
}
