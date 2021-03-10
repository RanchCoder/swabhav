using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternQueueApp.Model
{
    class QueueAdapter<T> : IQueue<T> 
    {
        private LinkedList<T> _queue;

        public QueueAdapter()
        {
            this._queue = new LinkedList<T>();
        }

        public T Current => _queue.First();



        public int Count()
        {
            return _queue.Count;
        }

        public T Dequeue()
        {
            T itemToBeDequeued = _queue.First();
            _queue.RemoveFirst();
            return itemToBeDequeued;
        }


        public void Enqueue(T item)
        {
            _queue.AddLast(item);
        }

        public void PrintQueue()
        {
            IEnumerator queueEnumarator = _queue.GetEnumerator();
            while (queueEnumarator.MoveNext())
            {
                Console.WriteLine(queueEnumarator.Current);
            }

        }
       
    }
}
