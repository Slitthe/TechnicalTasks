using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamplesDisplay.Examples
{
    public class MultipleThreadsCalculateExample : IExample
    {
        public MultipleThreadsCalculateExample()
        {
            StartMessage = ""; ;
            Name = "Multiple threads parallel calculation";
        }

        public volatile int Sum = default(int);
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";
            Sum = default(int);

            var taskList = new List<Task<int>>();
            int amountToTake = 3;

            var numList = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                numList.Add(i);
            }
            
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numList.Count; i += amountToTake)
            {
                List<int> sliceToCalculate = numList.Skip(i).Take(amountToTake).ToList();
                var t = Calculate(sliceToCalculate);

                // thread safe integer adding upon each task completion
                t.ContinueWith(task =>
                {
                    consoleText +=LogThread($"Minisum is: {task.Result}");
                    Interlocked.Add(ref Sum, task.Result);
                });
                taskList.Add(t);
            }
            
            

            Task.WhenAll(taskList).Wait();
            consoleText += LogThread($"Final sum is: {Sum}");
            
            stopwatch.Stop();
            consoleText += LogThread($"Calculation time elapsed: {stopwatch.ElapsedMilliseconds} ms");


            return consoleText;
        }

        private static async Task<int> Calculate(List<int> nums)
        {
            return await Task.Run((() =>
            {
                var sum = 0;
                
                foreach (var num in nums)
                {
                    sum += num;
                }
                return sum;
            }));
        }

        private static string LogThread(string message)
        {
            return $"[{Thread.CurrentThread.ManagedThreadId}] {message}\n\n";
        }

    }
}
