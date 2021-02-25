using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixXOGameApp.Model
{
    class MatrixXO
    {
        public const string CENTER = "center";

        public const string LEFT = "left";

        public const string RIGHT = "right";

        public const string MIDDLE = "middle";


        private string[,] gamePad = new string[3, 3];

        public string[,] GamePad { get => gamePad; set => gamePad = value; }


        public static bool IsTopCornerAlignedBox(int x, int y)
        {
            if ((x == 0 && y == 0) || (x == 0 && y == 2))
            {
                return true;
            }
            return false;
        }

        public static bool IsBottomCornerAlignedBox(int x, int y)
        {
            if ((x == 2 && y == 0) || (x == 2 && y == 2))
            {
                return true;
            }
            return false;
        }

        public static bool IsMiddleAlignedBox(int x, int y)
        {
            if (x == 1 && y == 1)
            {
                return true;
            }
            return false;
        }


        public static string CheckAlignment(int x, int y)
        {
            if ((x == 0 && y == 1) || (x == 1 && y == 1) || (x == 2 && y == 1) || (x == 1 && y == 0) || (x == 1 && y == 2))
            {
                return CENTER;
            }
            else if ((x == 0 && y == 0 || (x == 1 && y == 0) || (x == 2 && y == 0)))
            {
                return LEFT;
            }
            else 
            {
                return RIGHT;
            }
        }       
        

        public void InitializeGamePad() {
         
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    gamePad[i,j] = "-";
                }
            }
        
        } 


    }
}
