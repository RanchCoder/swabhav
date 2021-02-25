using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceApp.Model;
namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice invoiceMessage = new Invoice(1,"Vishal Singh",0.024,0.18,1000);

            InvoicePrinter.PrintInvoiceDetail(invoiceMessage);
         
            Console.ReadLine();
        }

        
    }
}
