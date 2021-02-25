using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseThreeRollOrHoldApp.Model
{
    class Die
    {
        private int valueOfDie;

        
        public void RollDie()
        {
            Random random = new Random();
            valueOfDie = random.Next(1,7);
        }

        public int ValueOfDie { get => valueOfDie;}


    }
}
