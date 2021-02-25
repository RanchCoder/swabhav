using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalRateApp.Model
{
    class HoliRate : IFestivalRate
    {
        private double _interestRate = 0.04;
        double IFestivalRate.GetIntrestRate()
        {
            return _interestRate;
        }
    }
}
