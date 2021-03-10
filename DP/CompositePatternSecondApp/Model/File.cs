using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternSecondApp.Model
{
    class File : IStorable
    {
        private string _name;
        private double _size;
        private string _extension;

        public File(string name, double size, string extension)
        {
            _name = name;
            _size = size;
            _extension = extension;
        }

        public string Name { get => _name; set => _name = value; }
        public double Size { get => _size; set => _size = value; }
        public string Extension { get => _extension; set => _extension = value; }

        public void Display(StringBuilder dashes)
        {
            dashes.Append("\n---->"+Name+"."+Extension+" size: "+Size+"\n");
            Console.WriteLine(dashes);
        }
    }
}
