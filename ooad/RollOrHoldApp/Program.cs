using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollOrHoldApp
{
    class Program
    {
        static void Main(string[] args)
        {

            bool isPlaying = true;
            Console.WriteLine("To roll enter r/R  || To hold enter h/H");
            string userChoice;
            int turnScore = 0;
            int totalScore = 0;
            int randomRoll;
            int counter = 1;
            bool keepRolling = true;
            while (isPlaying)
            {
                if(totalScore >= 20)
                {
                    Console.WriteLine($"Total score {totalScore} has been reached\nTurns taken to reach : {counter}");

                    isPlaying = false;
                }
                else
                {
                    Console.WriteLine($"TURN {counter++}");
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

                            if (userChoice.ToLower().Equals("r"))
                            {
                                randomRoll = GenerateRandomNumber();
                                if (randomRoll != 1)
                                {
                                    Console.WriteLine($"Die : {randomRoll}");
                                    turnScore += randomRoll;
                                }
                                else
                                {
                                    Console.WriteLine($"You have rolled 1 , your total score will be set to zero");
                                    totalScore = 0;
                                    turnScore = 0;
                                }
                            }
                            else if (userChoice.ToLower().Equals("h"))
                            {
                                Console.WriteLine($"Score For Turn : {turnScore}");

                                totalScore += turnScore;
                                turnScore = 0;
                                Console.WriteLine($"Total score : {totalScore}");
                                keepRolling = false;

                            }

                        }

                    }
                    if (totalScore >= 20)
                    {
                        Console.WriteLine($"Total score {totalScore} has been reached\nTurns taken to reach : {counter}");
                        isPlaying = false;
                    }

                }
                
               
               
            }
            Console.ReadLine();
        }

      

        public static int GenerateRandomNumber()
        {

            Random random = new Random();
            return random.Next(1,7);
        }
    }
}
