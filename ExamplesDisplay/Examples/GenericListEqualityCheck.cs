using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class GenericListEqualityCheck : IExample
    {
        public GenericListEqualityCheck()
        {
            StartMessage = "asdsaa";
            Name = "asdasd";
        }

        public string StartMessage { get; set; }
        public string Name { get; set; }

        public string Display()
        {
            return "42";
        }
    }
}
