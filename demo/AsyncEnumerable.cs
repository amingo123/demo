//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//namespace AsyncEnumerable
//{
//    class Program
//    {
//        static async Task ConsumeAsyncSumSeqeunc(IAsyncEnumerable<int> sequence)
//        {
//            Console.WriteLine("ConsumeAsyncSumSeqeunc Called");

//            await foreach (var value in sequence)
//            {
//                Console.WriteLine($"Consuming the value: {value}");

//                // simulate some delay!
//                await Task.Delay(TimeSpan.FromSeconds(1));
//            };
//        }

//        private static async IAsyncEnumerable<int> ProduceAsyncSumSeqeunc(int count)
//        {
//            Console.WriteLine("ProduceAsyncSumSeqeunc Called");
//            var sum = 0;

//            for (var i = 0; i <= count; i++)
//            {
//                sum = sum + i;

//                // simulate some delay!
//                await Task.Delay(TimeSpan.FromSeconds(0.5));

//                yield return sum;
//            }
//        }

//        static async Task Main(string[] args)
//        {
//            const int count = 5;
//            Console.WriteLine("Starting Async Streams Demo!");

//            // Start a new task. Used to produce async sequence of data!
//            IAsyncEnumerable<int> pullBasedAsyncSequence = ProduceAsyncSumSeqeunc(count);

//            // Start another task; Used to consume the async data sequence!
//            var consumingTask = Task.Run(() => ConsumeAsyncSumSeqeunc(pullBasedAsyncSequence));

//            await Task.Delay(TimeSpan.FromSeconds(3));

//            Console.WriteLine("X#X#X#X#X#X#X#X#X#X# Doing some other work X#X#X#X#X#X#X#X#X#X#");

//            // Just for demo! Wait until the task is finished!
//            await consumingTask;

//            Console.WriteLine("Async Streams Demo Done!");
//        }

//        static async Task<int> SumFromOneToCountAsync(int count)
//        {
//            Console.WriteLine("SumFromOneToCountAsync called!");

//            var result = await Task.Run(() =>
//            {
//                var sum = 0;

//                for (var i = 0; i <= count; i++)
//                {
//                    sum = sum + i;
//                }
//                return sum;
//            });

//            return result;
//        }
//    }
//}}
