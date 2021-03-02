using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPViolationApp.Model
{
    class Robot : IWork
    {
       

        void IWork.StartWork()
        {
            Console.WriteLine("\n\nRobot Started to work");
        }

      
        void IWork.StopWork()
        {
            Console.WriteLine("Robot stopped working");
        }
    }
}
