using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class MutableImmutableExample : IExample
    {
        public MutableImmutableExample()
        {
            StartMessage = ""; ;
            Name = "Mutable/Immutable example";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            // SET UP DATA
            string immutableString = "Initial";
            var immutableStringList = new List<string>();
            immutableStringList.Add(immutableString);

            StringBuilder mutableString = new StringBuilder("Initial");
            var mutableStringList = new List<StringBuilder>();
            mutableStringList.Add(mutableString);

            // ADD DATA TO LIST
            for (int i = 0; i < 1; i++)
            {
                immutableString += " + ";
                immutableStringList.Add(immutableString);

                mutableString.Append(" + ");
                mutableStringList.Add(mutableString);
            }

            // CHECK REFERENCE EQUALS AND PRINT VALUE ITSELF
            consoleText += "Immutable string list\n";
            foreach (var currenctString in immutableStringList)
            {
                consoleText += $"\"{currenctString}\"\n";
            }
            consoleText += $"Value of the .ReferenceEquals between the two: {object.ReferenceEquals(immutableStringList[0], immutableStringList[1])}\n\n";

            consoleText += "Mutable string list\n";
            foreach (var currenctString in mutableStringList)
            {
                consoleText += $"\"{currenctString}\"\n";
            }
            consoleText += $"Value of the .ReferenceEquals between the two: {object.ReferenceEquals(mutableStringList[0], mutableStringList[1])}";


            // PERFORMANCE BETWEEN THE TWO
            consoleText += $"\n\n\nPerformance of the immutable string (string builder). Concatenating it 250.000 times\n";
            StringBuilder mutableStringPerformance = new StringBuilder();
            Stopwatch stopwatchForMutable = new Stopwatch();
            stopwatchForMutable.Start();

            for (int i = 0; i < 250_000; i++)
            {
                mutableStringPerformance.Append(" append ");
            }

            stopwatchForMutable.Stop();
            consoleText += $"{stopwatchForMutable.ElapsedMilliseconds}ms";



            consoleText += $"\n\n\nPerformance of the immutable string (given 1/10th of the load of the mutable string). Concatenating (.Append) it 25.000 times\n";
            string immutableStringPerformance = "";
            Stopwatch stopwatchForImmutable = new Stopwatch();
            stopwatchForImmutable.Start();

            for (int i = 0; i < 250_00; i++)
            {
                immutableStringPerformance += " append ";
            }

            stopwatchForImmutable.Stop();
            consoleText += $"{stopwatchForImmutable.ElapsedMilliseconds}ms";








            return consoleText;
        }

    }
}
