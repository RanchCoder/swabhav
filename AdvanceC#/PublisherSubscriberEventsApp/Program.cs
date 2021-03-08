using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherSubscriberEventsApp.Model;
namespace PublisherSubscriberEventsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NewsPublisher np = new NewsPublisher();
            NewsPaperDistributor navneetDistributor = new NewsPaperDistributor();
            np.NewsPublished += navneetDistributor.OnNewsPublish;

            np.StartNewsPrintingProcess();
            Console.ReadLine();
        }
    }

    class NewsPaperDistributor
    {
        public void OnNewsPublish()
        {
            Console.WriteLine($"Message From Distributor :)");
            Console.WriteLine($"News has been published, Get your copy at Navneet Paper Distributors pvt ltd.");
        }
    }
}
