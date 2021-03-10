using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternMealApp.Model
{
    interface Item
    {
         string Name();
         Packing Packing();
         float Price();

    }
}
