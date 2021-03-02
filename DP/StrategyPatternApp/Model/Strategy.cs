using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternApp
{
    interface Strategy
    {
        int DoOperation(int num1, int num2);
    }
}
