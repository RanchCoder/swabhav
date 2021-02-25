using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseOneRollOrHoldApp
{
    class Program
    {
        public const int TARGET_SCORE = 20;
        public const string ROLL = "r";
        public const string HOLD = "h";
        static void Main(string[] args)
        {

            PlayRollOrHold();
            Console.ReadLine();
        }

        public static void PlayRollOrHold()
        {
            bool isPlaying = true , keepRolling = true;
            
            int turnScore = 0, totalScore = 0, counter = 1;

            Console.WriteLine("To roll enter r/R  || To hold enter h/H");
            
            
            while (isPlaying)
            {
                if (CheckForTargetScore(ref totalScore,ref turnScore))
                {
                    PrintResult(counter);
                    isPlaying = false;
                }
                else
                {
                    Console.WriteLine($"\n\nTURN {counter++}");
                    keepRolling = true;
                    PlayATurn(ref keepRolling,ref turnScore,ref totalScore);    
                }
            }
            Console.ReadLine();
        }


        public static void PlayATurn(ref bool keepRolling,ref int turnScore, ref int totalScore)
        {
            string userChoice;
            int randomRoll;
            bool isUserChoosingToRoll, isUserChoosingToHold;
            while (keepRolling)
            {                
                    Console.Write("Roll or Hold  (r/h) : ");
                    userChoice = Console.ReadLine();                   
                    isUserChoosingToRoll = userChoice.ToLower().Equals(ROLL);
                    isUserChoosingToHold = userChoice.ToLower().Equals(HOLD);
                    
                if (isUserChoosingToRoll)
                    {
                        randomRoll = GenerateRandomNumber();
                        if (randomRoll != 1)
                        {
                            
                            Console.WriteLine($"Die : {randomRoll}");
                            turnScore += randomRoll;
                            if(CheckForTargetScore(ref totalScore,ref turnScore))
                            {

                                PrintTurnScore(ref turnScore, ref totalScore);
                                keepRolling = false;
                            }
                        }
                        else
                        {
                            GameReset(ref turnScore, ref totalScore);
                        }
                }
                else if (isUserChoosingToHold)
                {
                        PrintTurnScore(ref turnScore, ref totalScore);
                        keepRolling = false;
                }
                
            }
        }

        //BASIC UTILITY FUNCTIONS
        public static int GenerateRandomNumber()
        {

            Random random = new Random();
            return random.Next(1, 7);
        }

        public static void GameReset(ref int turnScore, ref int totalScore)
        {
            Console.WriteLine($"You have rolled 1 , your total score will be set to zero");
            totalScore = 0;
            turnScore = 0;

        }

        //PRINT UTILITY FUNCIIONS
        public static void PrintResult(int totalTurns)
        {
            Console.WriteLine($"Target score {TARGET_SCORE} has been reached\nTurns taken to reach : {totalTurns}");

        }
       
        public static void PrintTurnScore(ref int turnScore,ref int totalScore)
        {
            Console.WriteLine($"Score For Turn : {turnScore}");
            totalScore += turnScore;
            turnScore = 0;
            Console.WriteLine($"Total score : {totalScore}");
        }

       //TOTAL SCORE TRACKER UTILITY FUNCTION       
        public static bool CheckForTargetScore(ref int totalScore,ref int turnScore)
        {
            if(totalScore >=20 || turnScore >= 20)
            {
                return true;
            }
            return false;
        }

    }
}

