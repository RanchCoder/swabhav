using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPatternApp.Model;
namespace FactoryPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                AutoMobileFactory factory = new AutoMobileFactory();
                IAutomobile bmw = factory.Make(Auto.AutoType.BMW);
                bmw.Start();
                bmw.Stop();

                IAutomobile audi = factory.Make(Auto.AutoType.AUDI);
                audi.Start();
                audi.Stop();

                IAutomobile tesla = factory.Make(Auto.AutoType.TESLA);
                tesla.Start();
                tesla.Stop();

                IAutomobile hyundai = factory.Make(Auto.AutoType.UNDEFINED);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
            
        }
    }
}
