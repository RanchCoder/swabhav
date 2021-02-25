using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixXOGameApp.Model;
namespace MatrixXOGameApp
{
    class Program
    {
        const string PLAYER_1_CHOICE = "X";
        const string PLAYER_2_CHOICE = "0";
        const string PLAYER_1 = "player_1";
        const string PLAYER_2 = "player_2";
        const int INDEX_0 = 0;
        const int INDEX_1 = 1;
        const int INDEX_2 = 2;
        const int INDEX_3 = 3;
        const int INDEX_4 = 4;
        const int INDEX_5 = 5;
        const int INDEX_6 = 6;
        const int INDEX_7 = 7;
        const int INDEX_8 = 8;
        static int counter = 0;

        static void Main(string[] args)
        {
            MatrixXO gamePad = new MatrixXO();
            gamePad.InitializeGamePad();
            PrintGamePad(gamePad.GamePad);
            StartGamePlay(gamePad.GamePad);
           
            Console.ReadLine();
        }


        public static void StartGamePlay(string[,] gamePad)
        {
            bool gamePlayIsOn = true;
            while (gamePlayIsOn)
            {
                if(counter > 10)
                {
                    gamePlayIsOn = false;
                    break;
                }
                else
                {
                    UserPlays(PLAYER_1_CHOICE, gamePad,PLAYER_1);
                    PrintGamePad(gamePad);
                    UserPlays(PLAYER_2_CHOICE, gamePad,PLAYER_2);
                    PrintGamePad(gamePad);
                }
            }
        }

        public static void UserPlays(string playerChoice,string[,] gamePad, string playerName)
        {
            
            int boxChoice;
            Console.Write($"Number of Boxes still empty : {9 - counter}\n");
            Console.Write($"Box choice of Player {playerName} : ");
            boxChoice = GetUserBoxChoice();
            if (boxChoice != -1)
            {

                if (IsBoxEmpty(ref boxChoice, gamePad))
                {
                    FillBox(ref boxChoice, gamePad,playerChoice);
                }
            }
        }

        public static void FillBox(ref int boxChoice,string[,] gamePad,string playerChoice)
        {
            switch (boxChoice)
            {
                case 1: { 
                        gamePad[INDEX_0, INDEX_0] = playerChoice;
                        CheckAlignment(gamePad, INDEX_0, INDEX_0);
                    } break;
                case 2: {
                        gamePad[INDEX_0, INDEX_1] = playerChoice;
                        CheckAlignment(gamePad, INDEX_0, INDEX_1);
                    } break;
                case 3: {
                        gamePad[INDEX_0, INDEX_2] = playerChoice;
                        CheckAlignment(gamePad, INDEX_0, INDEX_2);
                    } break;
                case 4: {
                        gamePad[INDEX_1, INDEX_0] = playerChoice;
                        CheckAlignment(gamePad, INDEX_1, INDEX_0);
                    } break;
                case 5: {
                        gamePad[INDEX_1, INDEX_1] = playerChoice;
                        CheckAlignment(gamePad, INDEX_1, INDEX_1);
                    } break;
                case 6: {
                        gamePad[INDEX_1, INDEX_2] = playerChoice;
                        CheckAlignment(gamePad, INDEX_1, INDEX_2);
                    } break;
                case 7: {
                        gamePad[INDEX_2, INDEX_0] = playerChoice;
                        CheckAlignment(gamePad, INDEX_2, INDEX_0);
                    } break;
                case 8: {
                        gamePad[INDEX_2, INDEX_1] = playerChoice;
                        CheckAlignment(gamePad, INDEX_2, INDEX_1);
                    } break;
                case 9: { 
                        gamePad[INDEX_2, INDEX_2] = playerChoice;
                        CheckAlignment(gamePad, INDEX_2, INDEX_2);
                    } break;
                
            }
            counter++;

        }

        public static void CheckAlignment(string[,] gamePad,int x,int y)
        {
            string result = MatrixXO.CheckAlignment(x, y);
            if (result.Equals(MatrixXO.CENTER))
            {
                if (MatrixXO.IsMiddleAlignedBox(x, y))
                {

                }
            }
        }

        public static bool IsBoxEmpty(ref int boxChoice,string[,] gamePad)
        {
            switch (boxChoice)
            {
                case 1: return CheckBoxStatus(INDEX_0, INDEX_0, gamePad);
                case 2: return CheckBoxStatus(INDEX_0, INDEX_1, gamePad);
                case 3: return CheckBoxStatus(INDEX_0, INDEX_2, gamePad);
                case 4: return CheckBoxStatus(INDEX_1, INDEX_0, gamePad);
                case 5: return CheckBoxStatus(INDEX_1, INDEX_1, gamePad);
                case 6: return CheckBoxStatus(INDEX_1, INDEX_2, gamePad);
                case 7: return CheckBoxStatus(INDEX_2, INDEX_0, gamePad);
                case 8: return CheckBoxStatus(INDEX_2, INDEX_1, gamePad);
                case 9: return CheckBoxStatus(INDEX_2, INDEX_2, gamePad);
                default:return false;
            }
        }

        public static bool CheckBoxStatus(int x,int y,string[,] gamePad)
        {
            if(!gamePad[x,y].Equals("X") || !gamePad[x, y].Equals("0"))
            {
                return true;
            }
            return false;
        }
        public static int GetUserBoxChoice()
        {
            string userInput = Console.ReadLine();
            int returnResult;
            bool isFetchingInput = true;
            while (isFetchingInput)
            {
                if (Int32.TryParse(userInput, out returnResult))
                {
                    if(returnResult >= 1 && returnResult <= 9)
                    {
                        isFetchingInput = false;
                    }      

                    return returnResult;
                }
                else
                {
                    Console.WriteLine($"please enter numeric value");
                }
            }
            return -1;
        }

        public static void PrintGamePad(string[,] gamePad)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(gamePad[i,j] + " | ");
                }
                Console.WriteLine();
            }
        }

       
    }
}
