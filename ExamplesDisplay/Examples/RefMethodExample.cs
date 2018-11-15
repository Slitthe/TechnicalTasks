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
            string stringValueTypeExample = "Initial string.";

            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Initial Value of the \"{nameof(stringValueTypeExample)}\": ",
                stringValueTypeExample);

            ChangeStringWithoutRef(stringValueTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Value of the \"{nameof(stringValueTypeExample)}\" after calling the non-ref method: ", stringValueTypeExample);


            ChangeStringWithRef(ref stringValueTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Value of the \"{nameof(stringValueTypeExample)}\" after calling the ref method: ", stringValueTypeExample);


            // REFERENCE TYPE
            RefExampleModel refTypeExample = new RefExampleModel() { Name = "Initial Name"};

            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Guid of the initial object: ", refTypeExample.GuidValue);

            ChangeRefTypeWithoutRef(refTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Guid of the initial object passed through an non-ref method (attempting to reassign it inside the method): ", refTypeExample.GuidValue);

            ChangeRefTypeWithRef(ref refTypeExample);
            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                $"Guid of the initial object passed through an ref method: (attempting to reassign it inside the method)", refTypeExample.GuidValue);

            return consoleText; 
        }

        // VALUE TYPE
        public void ChangeStringWithoutRef(string numberToChange)
        {
            numberToChange = "Changed inside the non-ref method";
        }
        public void ChangeStringWithRef(ref string numberToChange)
        {
            numberToChange = "Changed inside the ref method.";
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
        public string GuidValue { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
