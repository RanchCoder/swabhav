using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternApp.Model
{
    class OperationMultiply : Strategy
    {
        int Strategy.DoOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}