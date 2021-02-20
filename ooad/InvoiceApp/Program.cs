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

            PrintInvoiceDetail(invoiceMessage);
            Console.ReadLine();
        }

        public static void PrintInvoiceDetail(Invoice invoiceMessage)
        {
            Console.WriteLine($"Name : {invoiceMessage.Name}\nAmount : Rs{invoiceMessage.Amount}/-\nDiscount :Rs{invoiceMessage.ComputeDiscount()}/-" +
                $"\nG.S.T :Rs{invoiceMessage.ComputeGst()}/-" +
                $"\nFinal Amount :Rs{invoiceMessage.CalculateTotalCost()}/-");
            

        }
    }
}
