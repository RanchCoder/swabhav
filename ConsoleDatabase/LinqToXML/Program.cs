using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {

            XElement xelement = XElement.Load(@"C:\\swabhav\ConsoleDatabase\LinqToXML\Employee.xml");
            IEnumerable<XElement> employees = xelement.Elements();
            Console.WriteLine("First Name ");

            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Element("name").Value);
            }
            Console.ReadLine();
        }
    }
}
