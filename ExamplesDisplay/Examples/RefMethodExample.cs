using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class RefMethodExample : IExample
    {
        public RefMethodExample()
        {
            StartMessage = ""; ;
            Name = "Boxing/unboxing example";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            // VALUE TYPE
            int numberValueTypeExample = 0;

            ChangeNumberWithoutRef(numberValueTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Value of the{nameof(numberValueTypeExample)} after calling the non-ref method: ", numberValueTypeExample);


            ChangeNumberWithRef(ref numberValueTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Value of the{nameof(numberValueTypeExample)} after calling the non-ref method: ", numberValueTypeExample);


            // REFERENCE TYPE
            RefExampleModel refTypeExample = new RefExampleModel() { Name = "Initial Name"};

            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Guid of the initial object: ", refTypeExample.GUID);

            ChangeRefTypeWithoutRef(refTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Guid of the initial object passed through an non-ref method (attempting to reassign it inside the method): ", refTypeExample.GUID);

            ChangeRefTypeWithRef(ref refTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Guid of the initial object passed through an ref method: (attempting to reassign it inside the method)", refTypeExample.GUID);

            return consoleText; 
        }

        // VALUE TYPE
        public void ChangeNumberWithoutRef(int numberToChange)
        {
            numberToChange = 42;
        }
        public void ChangeNumberWithRef(ref int numberToChange)
        {
            numberToChange = 42;
        }

        // REFERENCE TYPE
        public void ChangeRefTypeWithoutRef(RefExampleModel refExampleInstance)
        {
            refExampleInstance = new RefExampleModel {Name = "Modified inside the method."};
        }
        public void ChangeRefTypeWithRef(ref RefExampleModel refExampleInstance)
        {
            refExampleInstance = new RefExampleModel {Name = "Modified inside the method."};
        }


    }

    // MODEL TO USE IN THE DEMO
    public class RefExampleModel
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
