using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Object_Reference_App.model
{
    class Rectangle
    {
        private float height;
        private float width;

        public float GetWidth()
        {
            return this.width;
        }

        public float GetHeight()
        {
            return this.height;
        }

        public void SetWidth(float width)
        {
            this.width = width;

        }

        public void SetHeight(float height)
        {
            this.height = height;
        }

        
    }
}
