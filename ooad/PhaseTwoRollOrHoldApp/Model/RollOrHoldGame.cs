using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseTwoRollOrHoldApp.Model
{
    class RollOrHoldGame
    {
        public static int TARGET_SCORE = 20;
        public static string ROLL = "r";
        public static string HOLD = "h";

        private bool isPlaying, keepRollingDice;
        private string userChoice;
        private int turnScore, totalScore,valueFromDiceRoll;

        
        public RollOrHoldGame(bool isPlaying, int turnScore, int totalScore)
        {
            this.isPlaying = isPlaying;          
            this.turnScore = turnScore;
            this.totalScore = totalScore;           
        }

        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public bool KeepRollingDice { get => keepRollingDice; set => keepRollingDice = value; }
        public string UserChoice { get => userChoice; set => userChoice = value; }
        public int TurnScore { get => turnScore; set => turnScore = value; }
        public int TotalScore { get => totalScore; set => totalScore = value; }
        public int ValueFromDiceRoll { get => valueFromDiceRoll; set => valueFromDiceRoll = value; }




        //TOTAL SCORE TRACKER UTILITY FUNCTION       
        public  bool CheckForTargetScore(ref int totalScore, ref int turnScore)
        {
            if (totalScore >= 20 || turnScore >= 20)
            {
                return true;
            }
            return false;
        }

        public  void GameReset(ref int turnScore, ref int totalScore)
        {
           
            totalScore = 0;
            turnScore = 0;

        }

    }
}
