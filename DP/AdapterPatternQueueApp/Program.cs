using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterPatternQueueApp.Model;
namespace AdapterPatternQueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueAdapter<int> queue= new QueueAdapter<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.PrintQueue();
            queue.Dequeue();
            Console.WriteLine("List After Dequeue");
            queue.PrintQueue();
            Console.ReadLine();
        }

        
    }
}
