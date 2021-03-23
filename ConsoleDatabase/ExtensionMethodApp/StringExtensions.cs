using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string s)
        {
            int n = s.Length;
            string str = "";
            for(int i = 0; i < n; i++)
            {
                if(s[i] == ' ')
                {
                    str  = str + '_';
                }
                else
                {
                    str = str + (s[i]);
                }
            }
            return str;
        }
    }
}
