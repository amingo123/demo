using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTool2
{
    class ProducerSample
    {
        static void Main(string[] args)
        {
            //ThreadPool.SetMinThreads(10, 10);

            while (true)
            {
                Task.Run((Action)Producer);
                //Task.Run(Producer2);
                //Thread.Sleep(100);
            }
        }

        static void Producer()
        {
            var result = Process().Result;//.ConfigureAwait(false);
        }

        static async Task Producer2()
        {
            await Process();
        }

        static async Task<bool> Process()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            Console.WriteLine("Ended - " + DateTime.Now.ToLongTimeString());
            return true;
        }
    }
}