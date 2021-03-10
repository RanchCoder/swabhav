using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternApp.Model
{
    public class Control : IHtml
    {
        private string _tag;
        private string _type;
        private string _value;

        public StringBuilder control = new StringBuilder();
        public Control(String tag)
        {
            this._tag = tag;
        }

        public Control(string tag,string type,string value)
        {
            this._tag = tag;
            this._type = type;
            this._value = value;
            ParseHtml();
        }

        
        public StringBuilder ParseHtml()
        {
            if(this._type != null)
            {
                control.Append("<"+this._tag+" "+"type=\""+this._type+"\" value=\""+this._value+"\">");
                control.Append("</"+this._tag+">");
                return control;
            }
            else
            {
                control.Append("<" + this._tag +">");
                control.Append("</" + this._tag + ">");
                return control;
            }
        }
        public override string ToString()
        {
            return control.ToString();
        }
    }
}
