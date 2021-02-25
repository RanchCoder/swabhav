using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseThreeRollOrHoldApp.Model
{
    class Game
    {
        private int turnScore;
        private Die die = new Die();
        private int totalScore;
        private bool isTurnOver;
        private bool isGameOver;

        public int TurnScore { get => turnScore; set => turnScore = value; }
        public int TotalScore { get => totalScore; set => totalScore = value; }
        public bool IsTurnOver { get => isTurnOver; set => isTurnOver = value; }
        public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
        internal Die Die { get => die; set => die = value; }
    }

}
