using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class ExpressionBodyExample : IExample
    {
        public ExpressionBodyExample()
        {
            StartMessage = ""; ;
            Name = "Expression-body members";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            
            return consoleText;
        }

    }

    public class ExpressionBodyMembersExample
    {
        private int _result;

        // constructor
        public ExpressionBodyMembersExample(int initialValue) => _result = initialValue; 
        // method
        public int Add(int a, int b) => a + b;

        // read-only property
        public int Result => _result;

        // property with getters and setters
        public int ResultProp
        {
            get => _result;
            set => _result = value;
        }
 
    }
}
