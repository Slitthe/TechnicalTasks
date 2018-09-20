using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class YieldFiboTwo : IExample
    {
        public string StartMessage { get; set; }  = "asdsadsa";
        public string Name { get; set; } = "Fibonacci (second example) sequence using yield return";
        public string Display()
        {
            string consoleText = "";
            int maxValue = 1_000_000;
            Console.WriteLine($"Gettings all the fibonacci numbers that are less than {maxValue} \n");
            foreach (var fibo in GetFiboNumbers(1_000_000))
            {
                consoleText += fibo + "\n";
            }
            return consoleText;
        }

        private static IEnumerable<int> GetFiboNumbers(int maxValue)
        {
            int[] fiboBase = new int[] { 0, 1 };



            while (fiboBase[1] < maxValue)
            {

                yield return fiboBase[1];

                var currentLastFibo = fiboBase[0] + fiboBase[1];
                fiboBase[0] = fiboBase[1];
                fiboBase[1] = currentLastFibo;

            }
        }
    }

}
