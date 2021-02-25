using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LspViolationTest.Model
{
    class Square : Rectangle
    {
        private int side;

        public Square(int side) : base(side,side)
        {
            this.side = side;
        }


        public override int Length { get => base.Length; set => base.Length = value; }
        // public override int Length { get => this.side; set => this.side = value; }


        public override int Breadth { get => base.Breadth; set => base.Breadth = value; }

        // public override int Length { get => this.side; set => this.side = value; }
    }
}
