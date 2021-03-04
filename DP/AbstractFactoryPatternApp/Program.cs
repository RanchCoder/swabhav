
using AbstractFactoryPatternApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MobileShop shop = new MobileShop();
                Console.Write("Enter mobile brand you are looking for : ");
                string userChoiceOfBrand = Console.ReadLine();
                IMobileFactory  mobileFactory = shop.BuyMobile(userChoiceOfBrand);
                PrintDetails(mobileFactory);
               

            }catch(NoSuchMobileExcpetion ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static void PrintDetails(IMobileFactory mobileFactory)
        {
            IMobileOS os = mobileFactory.GetMobileOS();
            IMobileManufacturer brandOfMobile = mobileFactory.GetMobileManufacturer();

            Console.WriteLine($"Company Name : {brandOfMobile.CompanyDetails() } -- OS of Mobile : {os.OSDetails()}");
        }
    }
}
