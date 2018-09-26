using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExamplesDisplay;

namespace ExamplesDisplay.Examples
{
    class IListExample : IExample
    {
        public string StartMessage { get; set; } = "IList";
        public string Name { set; get; } = "IList";



        public string Display()
        {
            // IEnumerable only allows the given object to be iterated (usually with a foreach)
            var displayText = "";

            IList<string> listExample = new List<string>() { "one", "two", "three", "four" };

            displayText += DisplayFormatHelpers.DescriptionValueFormat
                (
                    "Initial list which implements the IList interface", 
                    DisplayFormatHelpers.WriteList<string>(listExample)
                );

            Console.WriteLine(listExample[2]);
            displayText += DisplayFormatHelpers.DescriptionValueFormat
                (
                    "Access item by index, [2]", 
                    listExample[2]
                );
            //listExmaple.IndexOf("two");
            Console.WriteLine(listExample[2]);
            displayText += DisplayFormatHelpers.DescriptionValueFormat
                (
                    "Get index of a specific item, \"three\"",
                    listExample.IndexOf("three")
                );

            //listExmaple.Insert(1, "inserted item");
            listExample.Insert(2, "inserted");
            displayText += DisplayFormatHelpers.DescriptionValueFormat
                (
                    "Insert item at a specific index, \"inserted\" at [2]",
                    DisplayFormatHelpers.WriteList<string>(listExample)
                );

            //listExmaple.RemoveAt(3);
            listExample.RemoveAt(3);
                displayText += DisplayFormatHelpers.DescriptionValueFormat
                (
                    "Remove the item at index [3]",
                    DisplayFormatHelpers.WriteList<string>(listExample)
                );

            return displayText;
        }

    }

   
}
