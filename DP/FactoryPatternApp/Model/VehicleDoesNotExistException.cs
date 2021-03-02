using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp.Model
{
    class VehicleDoesNotExistException : Exception
    {
        public VehicleDoesNotExistException() : base("Vehicle does not exist") { }
    }
}
