using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp.Model
{
    class AutoMobileFactory
    {
        public IAutomobile Make(Auto.AutoType type)
        {
            if(type == Auto.AutoType.AUDI)
            {
                return new Audi();
            }
            else if (type == Auto.AutoType.BMW)
            {
                return new Bmw();
            }
            else if(type == Auto.AutoType.TESLA)
            {
                return new Tesla();
            }
            else 
            {
                throw new VehicleDoesNotExistException(); 
            }
        }
    }
}
