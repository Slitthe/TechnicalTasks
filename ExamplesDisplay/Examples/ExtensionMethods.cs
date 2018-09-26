using System;
using System.Collections.Generic;
using System.Text;
using PlaceWithExtensionMethod;

namespace ExamplesDisplay.Examples
{
    class ExtensionMethods : IExample
    {
        public ExtensionMethods()
        {
            StartMessage = "Extension method for the int type which returns that int + 1";
            Name = "Extension methods";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }

        public string Display()
        {
            var consoleText = "";

            int num = 42;
            consoleText += DisplayFormatHelpers.DescriptionValueFormat("Integer before using the extension method AddOne()", num.ToString());

            num = num.AddOne();
            consoleText += DisplayFormatHelpers.DescriptionValueFormat("Integer after using the extension method AddOne()", num.ToString());

            return consoleText;


        }


    }
}

namespace PlaceWithExtensionMethod
{
    public static class ExtensionClass
    {
        public static int AddOne(this int num)
        {
            return num + 1;
        }
    }
}
