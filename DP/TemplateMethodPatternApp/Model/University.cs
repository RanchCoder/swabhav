using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPatternApp.Model
{
    public abstract class University
    {
        public abstract void FillForm();
        public abstract void GetList();
        public abstract void FeePayment();

        public void StartProcess()
        {
            FillForm();
            GetList();
            FeePayment();
        }
    }
}
