using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhaseTwoRollOrHoldApp.Model;
namespace PhaseTwoRollOrHoldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RollOrHoldGame rollOrHoldGameInstance = new RollOrHoldGame(true,0,0);
            PlayRollOrHold(rollOrHoldGameInstance);

        }


        public static void PlayRollOrHold(RollOrHoldGame obj)
        {
            // bool isPlaying = true, keepRolling = true;
            
            obj.KeepRollingDice = true;
            int turnScore = 0, totalScore = 0, counter = 1;

            Console.WriteLine("To roll enter r/R  || To hold enter h/H");

            while (obj.IsPlaying)
            {
                if (obj.CheckForTargetScore(ref totalScore, ref turnScore))
                {
                    PrintResult(ref counter);
                    obj.IsPlaying = false;
                }
                else
                {
                    Console.WriteLine($"\n\nTURN {counter++}");
                    obj.KeepRollingDice = true;
                    PlayATurn(obj, ref turnScore, ref totalScore);
                }
            }
            Console.ReadLine();
        }


        public static void PlayATurn(RollOrHoldGame instanceOfGame, ref int turnScore, ref int totalScore)
        {
            string userChoice;
            int randomRoll;
            bool isUserChoosingToRoll, isUserChoosingToHold;
            while (instanceOfGame.KeepRollingDice)
            {
                Console.Write("Roll or Hold  (r/h) : ");
                userChoice = Console.ReadLine();
                isUserChoosingToRoll = userChoice.ToLower().Equals(RollOrHoldGame.ROLL);
                isUserChoosingToHold = userChoice.ToLower().Equals(RollOrHoldGame.HOLD);

                if (isUserChoosingToRoll)
                {
                    randomRoll = GenerateRandomNumber();
                    if (randomRoll != 1)
                    {

                        Console.WriteLine($"Die : {randomRoll}");
                        turnScore += randomRoll;
                        if (instanceOfGame.CheckForTargetScore(ref totalScore, ref turnScore))
                        {

                            PrintTurnScore(ref turnScore, ref totalScore);
                            instanceOfGame.KeepRollingDice = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You have rolled 1 , your total score will be set to zero");
                        instanceOfGame.GameReset(ref turnScore, ref totalScore);
                    }
                }
                else if (isUserChoosingToHold)
                {
                    PrintTurnScore(ref turnScore, ref totalScore);
                    instanceOfGame.KeepRollingDice = false;
                }

            }
        }

        //BASIC UTILITY FUNCTIONS
        public static int GenerateRandomNumber()
        {

            Random random = new Random();
            return random.Next(1, 7);
        }

        

        //PRINT UTILITY FUNCIIONS
        public static void PrintResult(ref int totalTurns)
        {
            Console.WriteLine($"Target score {RollOrHoldGame.TARGET_SCORE} has been reached\nTurns taken to reach : {totalTurns}");

        }

        public static void PrintTurnScore(ref int turnScore, ref int totalScore)
        {
            Console.WriteLine($"Score For Turn : {turnScore}");
            totalScore += turnScore;
            turnScore = 0;
            Console.WriteLine($"Total score : {totalScore}");
        }

    }
}
