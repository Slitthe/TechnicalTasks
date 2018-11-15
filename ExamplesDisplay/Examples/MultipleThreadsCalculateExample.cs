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

            //var numList = new List<int>();

            //for (int i = 0; i < 1001; i++)
            //{
            //    numList.Add(i);
            //}

            var first1000Ints = Enumerable.Range(0, 1001).ToList();

            var stopwatch = Stopwatch.StartNew();

            //foreach (int first1000Int in first1000Ints)
            //{
            //    List<int> sliceToCalculate = first1000Ints.Skip(first1000Int).Take(amountToTake).ToList();
            //    Task<int> calculateTask = Calculate(sliceToCalculate);

            //    // adding the result to the sum in a Thread-safe way (Interlocked) class
            //    calculateTask.ContinueWith(task =>
            //    {
            //        consoleText += LogThread($"Minisum is: {task.Result}");
            //        Interlocked.Add(ref Sum, task.Result);
            //    });
            //    taskList.Add(calculateTask);
            //}

            for (int i = 0; i < first1000Ints.Count; i += amountToTake)
            {
                List<int> sliceToCalculate = first1000Ints.Skip(i).Take(amountToTake).ToList();
                Task<int> calculateTask = Calculate(sliceToCalculate);

                // adding the result to the sum in a Thread-safe way (Interlocked) class
                calculateTask.ContinueWith(task =>
                {
                    consoleText += LogThread($"Minisum is: {task.Result}");
                    //lock (this)
                    //{
                    //    var partialSum = Sum + task.Result;
                    //    Sum = partialSum;

                    //}

                    Interlocked.Add(ref Sum, task.Result);
                });
                taskList.Add(calculateTask);
            }


            // waits for all the calculate slice tasks to complete
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
                int sum = 0;
                
                foreach (int num in nums)
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
