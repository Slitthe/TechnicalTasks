using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class EnumerableExample : IExample
    {
        public string StartMessage { get; set; } = "Custom IEnumerable";
        public string Name { set; get; } = "Simulating a foreach using an IEnumerable";



        public string Display()
        {
            // IEnumerable only allows the given object to be iterated (usually with a foreach)
            var displayText = "";
            List<string> colorsList = new List<string> { "Red", "Green", "Blue" };

            var colorsListEnumerator = colorsList.GetEnumerator();

            while(colorsListEnumerator.MoveNext())
            {
                displayText += colorsListEnumerator.Current + "\n";
            }
            return displayText;
        }

    }
}
