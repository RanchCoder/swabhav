using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Model
{
    class InvoicePrinter
    {
       
        public static void PrintInvoiceDetail(Invoice invoiceMessage)
        {
            Console.WriteLine($"Name : {invoiceMessage.Name}\nAmount : Rs{invoiceMessage.Amount}/-\nDiscount :Rs{invoiceMessage.ComputeDiscount()}/-" +
                $"\nG.S.T :Rs{invoiceMessage.ComputeGst()}/-" +
                $"\nFinal Amount :Rs{invoiceMessage.CalculateTotalCost()}/-");


        }
    }
}
