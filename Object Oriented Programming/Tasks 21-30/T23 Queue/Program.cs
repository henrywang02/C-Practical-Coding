using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T23_Queue
{
    class CheckoutQueue
    {
        private Queue<string> queue;

        public CheckoutQueue()
        {
            queue = new Queue<string>();
        }

        public void GoToQueue(string name)
        {
            queue.Enqueue(name);
            Console.WriteLine($"{name} has joined the queue.");
        }

        public string ExitQueue()
        {
            if (queue.Count > 0)
            {
                string name = queue.Dequeue();
                Console.WriteLine($"{name} has exited the queue.");
                return name;
            }
            else
            {
                Console.WriteLine("The queue is empty.");
                return null;
            }
        }

        public int Length
        {
            get { return queue.Count; }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            CheckoutQueue checkoutQueue = new CheckoutQueue();
            checkoutQueue.GoToQueue("Alice");
            checkoutQueue.GoToQueue("Bob");
            checkoutQueue.GoToQueue("Charlie");

            Console.WriteLine($"Current queue length: {checkoutQueue.Length}");

            checkoutQueue.ExitQueue();
            Console.WriteLine($"Current queue length: {checkoutQueue.Length}");

            checkoutQueue.ExitQueue();
            checkoutQueue.ExitQueue();
            Console.WriteLine($"Current queue length: {checkoutQueue.Length}");
        }
    }
}
