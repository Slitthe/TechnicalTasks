using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamplesDisplay.Examples
{
    public class ExplicitInterfaceImplementation : IExample
    {
        public ExplicitInterfaceImplementation()
        {
            StartMessage = "";
            Name = "Explicit interface implementation";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            Example exampleInstance = new Example();

            IOne exampleIOne = exampleInstance;
            ITwo exampleITwo = exampleInstance;

            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                "Accessing the method explicitly using the type of the variable",
                exampleIOne.SaySomething()
            );
            

            consoleText += DisplayFormatHelpers.DescriptionValueFormat(
                "Accessing the method explicitly by type casting the class itself",
                ((ITwo)exampleInstance).SaySomething()
            );

            return consoleText;
        }

        

        
    }

    public interface IOne
    {
        string SaySomething();
    }

    public interface ITwo
    {
        string SaySomething();
    }

    public class Example : IOne, ITwo
    {
        string IOne.SaySomething()
        {
            return "Explicit interface method implementation for the \"IOne\"";
        }

        string ITwo.SaySomething()
        {
            return "Explicit interface method implementation for the \"ITwos\"";
        }
    }
}
