using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            var exampleInstance = new Example();

            IOne exampleIOne = exampleInstance;
            ITwo exampleITwo = exampleInstance;
            
            consoleText += exampleIOne.SaySomething();
            consoleText += "\n";
            consoleText += exampleITwo.SaySomething();
            
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
