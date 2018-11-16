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
            Name = "Ref/no-ref methods";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            // VALUE TYPE
            string stringValueTypeExample = "Initial string.\n";
            consoleText += $"Initial Value of the \"{nameof(stringValueTypeExample)}\": \n---{stringValueTypeExample}\n";

            ChangeStringWithoutRef(stringValueTypeExample);
            consoleText += $"Value of the \"{nameof(stringValueTypeExample)}\" after calling the non-ref method: \n---{stringValueTypeExample}";
            
            ChangeStringWithRef(ref stringValueTypeExample);
            consoleText += $"Value of the \"{nameof(stringValueTypeExample)}\" after calling the ref method: \n---{stringValueTypeExample}\n\n";


            // REFERENCE TYPE
            RefExampleModel refTypeExample = new RefExampleModel() { Name = "Initial Name"};
            consoleText += $"Guid of the initial object: \n---{refTypeExample.GuidValue}\n";

            ChangeRefTypeWithoutRef(refTypeExample);
            consoleText += $"Guid of the initial object passed through an non-ref method (attempting to reassign it inside the method): \n---{refTypeExample.GuidValue}\n";

            ChangeRefTypeWithRef(ref refTypeExample);
            consoleText += $"Guid of the initial object passed through an ref method: (attempting to reassign it inside the method) \n---{refTypeExample.GuidValue}\n";

            return consoleText; 
        }

        // VALUE TYPE
        public void ChangeStringWithoutRef(string stringToChange)
        {
            stringToChange = "Changed inside the non-ref method";
        }
        public void ChangeStringWithRef(ref string stringToChange)
        {
            stringToChange = "Changed inside the ref method.";
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
