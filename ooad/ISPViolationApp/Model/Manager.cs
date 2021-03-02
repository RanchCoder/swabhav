using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPViolationApp.Model
{
    class Manager : IWorkEat
    {
        void IWorkEat.StartEat()
        {
            Console.WriteLine("Manager Eats");
        }

        void IWorkEat.StartWork()
        {
            Console.WriteLine("Manager Started to work");
        }

        void IWorkEat.StopEat()
        {
            Console.WriteLine("Manager stopped eating");
        }

        void IWorkEat.StopWork()
        {
            Console.WriteLine("manager stopped working");
        }
    }
}
