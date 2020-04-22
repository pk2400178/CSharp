using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        private const int limit = 3;
        private static BlockingCollection<int> list = new BlockingCollection<int>();

        static void Main(string[] args)
        {
            var producer = Task.Run(() => Producer());
            List<Task> consumers = new List<Task>();
            for(int i = 0; i< limit; i++)
            {
                var path = $"/App_Data/{i}";
                consumers.Add(Task.Run(() => Consumer(path)));
            }
            Console.ReadKey();
        }

        public static void Producer()
        {
            //Polling DB?
            for (int ctr = 0; ctr < 20; ctr++)
            {
                //Console.WriteLine($"Producer:{Thread.CurrentThread.ManagedThreadId} Add {ctr}");
                list.Add(ctr);
            }
        }

        public static void Consumer(string path)
        {
            foreach (var item in list.GetConsumingEnumerable())
            {
                Random rnd = new Random();
                var sleep = rnd.Next(100, 5000);
                Console.WriteLine($"Consumer:{ Thread.CurrentThread.ManagedThreadId},Path:{path}, Process Item: {item}, WaitTime:{sleep}");
                Thread.Sleep(sleep);
            }
        }
    }
}
