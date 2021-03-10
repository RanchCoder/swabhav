using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompositePatternSecondApp.Model
{
    class Folder : IStorable
    {
        private string _name;
        private static string dash = "-";
        private List<IStorable> children = new List<IStorable>();

        static int count = 0;

        public string Name { get => _name; set => _name = value; }

        public Folder(string name)
        {
            _name = name;
        }

        public void AddChildren(IStorable IStorable)
        {
            children.Add(IStorable);
        }

        public void Display(StringBuilder dashes)
        {
            dashes.Append("\n---"+Name);
            foreach(IStorable storable in children)
            {
                storable.Display(dashes);
            }

        }


    }
}
