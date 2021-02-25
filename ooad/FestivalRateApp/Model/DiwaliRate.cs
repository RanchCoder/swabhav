using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalRateApp.Model
{
    class DiwaliRate : IFestivalRate
    {
        private double _interestRate = 0.05;
        double IFestivalRate.GetIntrestRate()
        {
            return _interestRate;
        }
    }
}
