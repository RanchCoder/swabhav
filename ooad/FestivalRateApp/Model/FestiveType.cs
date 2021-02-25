using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalRateApp.Model
{
    class FestiveType
    {
        private double _normal = 0.07;
        private double _diwali = 0.05;
        private double _holi = 0.04;

        public double Normal { get => _normal; set => _normal = value; }
        public double Diwali { get => _diwali; set => _diwali = value; }
        public double Holi { get => _holi; set => _holi = value; }
    }
}
