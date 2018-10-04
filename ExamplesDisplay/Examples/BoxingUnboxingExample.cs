using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class BoxingUnboxingExample : IExample
    {
        public BoxingUnboxingExample()
        {
            StartMessage = ""; ;
            Name = "Boxing/unboxing example";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            int i = 42;
            object boxedI = i;
            int unboxedI = (int) boxedI;



            try
            {
                string wrongFormatToUnbox = (string) boxedI;
            }
            catch (InvalidCastException ex)
            {
                consoleText += DisplayFormatHelpers.DescriptionValueFormat("Trying to unbox with a wrong type", ex.Message);
            }

            return consoleText;
        }

    }
}
