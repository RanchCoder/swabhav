using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LspViolationTest.Model
{
    class Rectangle
    {
        private int length;
        private int breadth;

        public Rectangle(int length, int breadth)
        {
            this.length = length;
            this.breadth = breadth;
        }

        public virtual int Length { get => length; set => length = value; }
        public virtual int Breadth { get => breadth; set => breadth = value; }
    }
}
