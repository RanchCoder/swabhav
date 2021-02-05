using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guess_Game_App_3.model;

namespace Guess_Game_App_3
{
    class Program
    {
        public static void PlayTheGame(ref bool start,int numberToBeGuessed,int numberOfGuessByUser,ref GuessGame guessGame)
        {
            int numericValueOfUserGuess;
            while (start)
            {
                Console.WriteLine("Enter q or quit to stop the game");
                Console.WriteLine("Enter your guess :- ");
                string userGuessInput = Console.ReadLine();
                if (userGuessInput.ToLower() == "q" || userGuessInput.ToLower() == "quit")
                {
                    start = false;
                    Console.WriteLine("The game has ended, Thank you for being an active participant. :)");
                    break;
                }
                if (guessGame.IsUserInputNumeric(ref userGuessInput, out numericValueOfUserGuess))
                {
                    //bool returnValue = CompareUserGuess(ref numericValueOfUserGuess, ref numberToBeGuessed, ref numberOfGuessByUser);
                    string returnValue1 = guessGame.CompareUserGuess(ref numericValueOfUserGuess,guessGame.GetNumberToBeGuessed(), ref numberOfGuessByUser);
                    if (returnValue1 == "guess_is_high")
                    {
                        Console.WriteLine("Your guess is high, Think of a number which is smaller than your current guess.\n");
                    }
                    else if (returnValue1 == "guess_is_low") {
                        Console.WriteLine("Your guess is low, Think of a number which is bigger than your current guess.\n");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations, You have guessed it correctly. You made it only in {numberOfGuessByUser} moves.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a numeric guess \n");
                }
            }
        }

        static void Main(string[] args)
        {  //Case 1 :- No use of Object oriented features,functional approach
            GuessGame guessGame = new GuessGame();            
            guessGame.SetNumberOfGuessByUser(0);
            guessGame.SetNumberToBeGuessed();
            bool start = true;
            PlayTheGame(ref start,guessGame.GetNumberToBeGuessed(),guessGame.GetNumberOfGuessByUser(),ref guessGame);


            Console.ReadLine();
        }
    }
}
