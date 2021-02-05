using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Game_App
{
    class Program
    {
        static void Main(string[] args)
        {  //Case 1 :- No use of Object oriented features,functional approach
            Random random = new Random();
            int numberToBeGuessed = random.Next(100);            
            int numberOfGuessByUser = 0, numericValueOfUserGuess;             
            bool start = true;
            Console.WriteLine("Enter q or quit to stop the game");
            while (start)
            {
                Console.WriteLine("Enter your guess :- ");
                string userGuessInput = Console.ReadLine();
                if(userGuessInput.ToLower() == "q" || userGuessInput.ToLower() == "quit")
                {
                    start = false;
                    Console.WriteLine("The game has ended, Thank you for being an active participant. :)");
                    break;
                }
                if (int.TryParse(userGuessInput, out numericValueOfUserGuess))
                {
                    if (numericValueOfUserGuess < numberToBeGuessed)
                    {
                        numberOfGuessByUser += 1;
                        Console.WriteLine("Your guess is low, Think of a number which is bigger than your current guess.\n");
                    }
                    else if (numericValueOfUserGuess > numberToBeGuessed)
                    {
                        numberOfGuessByUser += 1;
                        Console.WriteLine("Your guess is high, Think of a number which is lower than your current guess \n");
                    }
                    else
                    {
                        numberOfGuessByUser += 1;
                        Console.WriteLine($"Congratulations, You have guessed it correctly. You made it only in {numberOfGuessByUser} moves.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a numeric guess \n");
                }
            }
            Console.ReadLine();
        }
    }
}
