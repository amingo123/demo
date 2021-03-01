using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace demo
{
    public class BlockingQueue<T>
    {
        private readonly object sync = new object();
        private readonly Queue<T> queue;
        public BlockingQueue()
        {
            queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            lock (sync)
            {
                queue.Enqueue(item);
                Monitor.PulseAll(sync);
            }

        }
        public T Dequeue()
        {
            lock (sync)
            {
                while (queue.Count == 0)
                    Monitor.Wait(sync);

                return queue.Dequeue();
            }

        }
    }
}
