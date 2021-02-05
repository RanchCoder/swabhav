using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleApp.model
{
    class Rectangle
    {
        private int height;
        private int width;
        private string color;

        public Rectangle()
        {

        }
        //using constructor to set values
        public Rectangle(int height,int width,string color)
        {
            this.height = height;
            this.width = width;
            this.color = color;
        }
        
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if(value < 1)
                {
                    this.height = 1;
                    
                }
                else if(value > 100)
                {
                    this.height = 100;
                }
                else
                {
                    this.height = value;
                }
                
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if(value < 1)
                {
                    this.width = 1;
                }else if(value > 100)
                {
                    this.width = 100;
                }
                else
                {
                    this.width = value;
                }
                
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        

      

        public string GetColor()
        {
            return this.color;
        }

        public void SetColor(string color)
        {
            color = color.ToLower();
            if(!color.Equals("green") || !color.Equals("red") || !color.Equals("blue"))
            {
                Console.WriteLine("Color is not equal to green or red or blue, setting it to black");
                color = "black";
            }
            this.color = color;
        }
    }
}
