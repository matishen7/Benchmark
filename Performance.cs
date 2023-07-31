using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MentorshipProgram.Session2.MyQueueProgram;

namespace Benchmark
{
    internal class Performance
    {
        static void Profile(string description, int iterations, Action func)
        {

            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            // warm up 
            func();
            // clean up
            GC.Collect();

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.Write(description);
            Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
        }

        //public static void Main(string[] args)
        //{
        //    var queue = new MyQueue();
        //    var q = new Queue<int>();
        //    int iterations = Int32.MaxValue / 2;
        //    int i = int.MinValue;vh
        //    Profile("my queue", iterations, () =>
        //        {
        //            queue.Push(i);
        //            queue.Pop();
        //        });

        //    i = int.MinValue;
        //    Profile("original queue push", iterations, () =>
        //    {
        //        q.Enqueue(i);
        //        q.Dequeue();
        //    });
        //}
    }
}
