using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhaseThreeRollOrHoldApp.Model;
namespace PhaseThreeRollOrHoldApp
{
    class Program
    {
        const int TARGET_SCORE = 20;
        public static string ROLL = "r";
        public static string HOLD = "h";
        static void Main(string[] args)
        {
            Game gameInstance = new Game();
            PlayRollOrHold(gameInstance);
        }


        public static void PlayRollOrHold(Game obj)
        {
            // bool isPlaying = true, keepRolling = true;

            bool IsPlaying = true;
            int turnScore = 0, totalScore = 0, counter = 1;

            Console.WriteLine("To roll enter r/R  || To hold enter h/H");

            while (IsPlaying)
            {
                if(CheckForTargetScore(obj.TurnScore, obj.TotalScore))
                {
                    PrintResult(ref counter);
                    IsPlaying = false;
                }
                else
                {
                    Console.WriteLine($"\n\nTURN {counter++}");
                    
                    PlayATurn(obj);
                }
            }
            Console.ReadLine();
        }


        public static void PlayATurn(Game instanceOfGame)
        {
            string userChoice;
            int randomRoll;
            bool isUserChoosingToRoll, KeepRollingDice = true, isUserChoosingToHold;
            while (KeepRollingDice)
            {
                Console.Write("Roll or Hold  (r/h) : ");
                userChoice = Console.ReadLine();
                isUserChoosingToRoll = userChoice.ToLower().Equals(ROLL);
                isUserChoosingToHold = userChoice.ToLower().Equals(HOLD);

                if (isUserChoosingToRoll)
                {
                    instanceOfGame.Die.RollDie();
                    randomRoll = instanceOfGame.Die.ValueOfDie;
                    if (randomRoll != 1)
                    {

                        Console.WriteLine($"Die : {randomRoll}");
                        instanceOfGame.TurnScore += randomRoll;
                        if (CheckForTargetScore(instanceOfGame.TurnScore,instanceOfGame.TotalScore))
                        {
                            
                            PrintTurnScore(instanceOfGame.TurnScore,instanceOfGame.TotalScore);
                            KeepRollingDice = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You have rolled 1 , your total score will be set to zero");
                        instanceOfGame.IsGameOver = true;
                        GameReset(instanceOfGame);
                    }
                }
                else if (isUserChoosingToHold)
                {
                    PrintTurnScore(instanceOfGame.TurnScore, instanceOfGame.TotalScore);
                    KeepRollingDice = false;
                }

            }
        }

        //BASIC UTILITY FUNCTIONS
        public static bool CheckForTargetScore(int totalScore,int turnScore)
        {
            if (totalScore >= 20 || turnScore >= 20)
            {
                return true;
            }
            return false;
        }



        //PRINT UTILITY FUNCIIONS
        public static void PrintResult(ref int totalTurns)
        {
            Console.WriteLine($"Target score {TARGET_SCORE} has been reached\nTurns taken to reach : {totalTurns}");

        }

        public static void PrintTurnScore(int turnScore,int totalScore)
        {
            Console.WriteLine($"Score For Turn : {turnScore}");
            totalScore += turnScore;
            turnScore = 0;
            Console.WriteLine($"Total score : {totalScore}");
        }

        public static void GameReset(Game obj)
        {
            obj.TurnScore = 0;
            obj.TotalScore = 0;
        }
    }
}
