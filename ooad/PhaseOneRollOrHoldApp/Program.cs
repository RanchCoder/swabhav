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
            string userChoice;
            int turnScore = 0, totalScore = 0, randomRoll, counter = 1;

            Console.WriteLine("To roll enter r/R  || To hold enter h/H");
            
            
            while (isPlaying)
            {
                if (CheckTotalScore(totalScore))
                {
                    PrintResult(counter);
                    isPlaying = false;
                }
                else
                {
                    Console.WriteLine($"\n\nTURN {counter++}");
                    keepRolling = true;
                    while (keepRolling)
                    {
                        if (turnScore >= 20 || totalScore >= 20)
                        {
                            keepRolling = false;
                        }
                        else
                        {
                            Console.Write("Roll or Hold  (r/h) : ");
                            userChoice = Console.ReadLine();

                            if (userChoice.ToLower().Equals(ROLL))
                            {
                                randomRoll = GenerateRandomNumber();
                                if (randomRoll != 1)
                                {
                                    Console.WriteLine($"Die : {randomRoll}");
                                    turnScore += randomRoll;
                                }
                                else
                                {
                                    GameReset(ref turnScore,ref totalScore);
                                }
                            }
                            else if (userChoice.ToLower().Equals(HOLD))
                            {
                                 PrintTurnScore(ref turnScore,ref totalScore);
                                 keepRolling = false;
                            }
                        }
                    }    
                }
            }
            Console.ReadLine();
        }

        public static  bool CheckTotalScore(int totalScore)
        {
            return totalScore >= TARGET_SCORE;
        }

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

        public static void GameReset(ref int turnScore,ref int totalScore)
        {
            Console.WriteLine($"You have rolled 1 , your total score will be set to zero");
            totalScore = 0;
            turnScore = 0;

        }

        public static int GenerateRandomNumber()
        {

            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}

