using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternApp.Model
{
    class ControlGroup : IHtml
    {
        private string _tag;
        private List<IHtml> controls = new List<IHtml>();
        public StringBuilder controlGroup = new StringBuilder();

        public ControlGroup(string tag)
        {
            this._tag = tag;
        }

        public void AddControl(IHtml element)
        {
            controls.Add(element);
        }

        public StringBuilder ParseHtml()
        {
            controlGroup.Append("<"+_tag+">\n");
            if(controls != null)
            {
                foreach(IHtml htmlElement in controls)
                {
                    controlGroup.Append(htmlElement.ParseHtml());
                }
            }
            controlGroup.Append("</"+_tag+">");
            return controlGroup;
        }

        public string ToString()
        {
            return controlGroup.ToString();
        }
    }
}
