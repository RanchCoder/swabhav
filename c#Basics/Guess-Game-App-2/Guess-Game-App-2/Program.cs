using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Game_App_2
{
    class Program
    {
        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(100);
        }
        public static bool CompareUserGuess(ref int numericValueOfUserGuess,ref int numberToBeGuessed,ref int numberOfGuessByUser)
        {
            if (numericValueOfUserGuess < numberToBeGuessed)
            {
                numberOfGuessByUser += 1;
                Console.WriteLine("Your guess is low, Think of a number which is bigger than your current guess.\n");
                return false;
            }
            else if (numericValueOfUserGuess > numberToBeGuessed)
            {
                numberOfGuessByUser += 1;
                Console.WriteLine("Your guess is high, Think of a number which is lower than your current guess \n");
                return false;
            }
            else
            {
                numberOfGuessByUser += 1;
                Console.WriteLine($"Congratulations, You have guessed it correctly. You made it only in {numberOfGuessByUser} moves.");
                return true;
            }
        }
        public static bool IsUserInputNumeric(ref string userGuessInput,out int numericValueOfUserGuess)
        {//check if user input in string or numeric
            if(int.TryParse(userGuessInput, out numericValueOfUserGuess))
            {
                return true;
            }
            return false;
        }

        public static void PlayTheGame(ref bool start,ref int numberToBeGuessed,ref int numberOfGuessByUser)
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
                if (IsUserInputNumeric(ref userGuessInput, out numericValueOfUserGuess))
                {
                    bool returnValue = CompareUserGuess(ref numericValueOfUserGuess, ref numberToBeGuessed, ref numberOfGuessByUser);
                    if (returnValue)
                    {
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
            int numberToBeGuessed = GenerateRandomNumber();            
            int numberOfGuessByUser = 0;
            bool start = true;
            PlayTheGame(ref start,ref numberToBeGuessed,ref numberOfGuessByUser);

          
            Console.ReadLine();
        }

    }
}
