using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PublisherSubscriberEventsApp.Model
{
    public delegate void NewsPublishEventHandler();
    class NewsPublisher
    {
        public event NewsPublishEventHandler NewsPublished;

        public void StartNewsPrintingProcess()
        {
            Console.WriteLine("News Printing in Process");
            Thread.Sleep(3000);
            Console.WriteLine("News printing done... Now publishing.");
            OnNewsPublish();
        }

        public void OnNewsPublish()
        {
            if(NewsPublished != null)
            {
                Thread.Sleep(1000);
                NewsPublished();
            }
        }
    }
}
