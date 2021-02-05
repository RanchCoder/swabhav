using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Game_App_3.model
{
    class GuessGame
    {
        private int numberToBeGuessed;
        private string userGuessInput;
        private int numberOfGuessByUser;
        const string GUESS_IS_LOW = "guess_is_low";
        const string GUESS_IS_HIGH = "guess_is_high";
        const string GUESS_IS_CORRECT = "guess_is_correct";
        bool start;

        public int GetNumberToBeGuessed() {
            return this.numberToBeGuessed;
        }
       

        public string GetUserGuessInput()
        {
            return this.userGuessInput;
        }

        public int GetNumberOfGuessByUser()
        {
            return this.numberOfGuessByUser;
        }

        public void SetNumberOfGuessByUser(int numberOfGuessByUser)
        {
             this.numberOfGuessByUser = numberOfGuessByUser;
        }

        public void SetNumberToBeGuessed()
        {
            this.numberToBeGuessed = GenerateRandomNumber();
        }

        public void SetUserGuessInput(string userGuessInput)
        {
            this.userGuessInput = userGuessInput;
        }

        public int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(100);
        }

        public bool IsUserInputNumeric(ref string userGuessInput, out int numericValueOfUserGuess)
        {//check if user input in string or numeric
            if (int.TryParse(userGuessInput, out numericValueOfUserGuess))
            {
                return true;
            }
            return false;
        }
        public string CompareUserGuess(ref int numericValueOfUserGuess, int numberToBeGuessed, ref int numberOfGuessByUser)
        {
            if (numericValueOfUserGuess < numberToBeGuessed)
            {
                numberOfGuessByUser += 1;
                
                return GUESS_IS_LOW;
            }
            else if (numericValueOfUserGuess > numberToBeGuessed)
            {
                numberOfGuessByUser += 1;
                
                return GUESS_IS_HIGH;
            }
            else
            {
                numberOfGuessByUser += 1;
                
                return GUESS_IS_CORRECT;
            }
        }
    }
}
