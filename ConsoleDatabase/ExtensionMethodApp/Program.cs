using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToConvert = "This is going to be in snakecase";
            string result = StringExtensions.ToSnakeCase(strToConvert);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
