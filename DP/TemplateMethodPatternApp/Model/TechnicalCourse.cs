using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPatternApp.Model
{
    class TechnicalCourse : University
    {
        public override void FeePayment()
        {
            Console.WriteLine($"Make payment to secure addmission to technical course");
        }

        public override void FillForm()
        {
            Console.WriteLine($"Fill form to proceed with your addmission to technical course");
        }

        public override void GetList()
        {
            Console.WriteLine($"Get Detailed list to check if you are selected for your technical course..");

        }
    }
}
