using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class Enumerable : IExample
    {
        public string StartMessage { get; set; } = "Custom IEnumerable";
        public string Name { set; get; } = "Custom IEnumerable";



        public string Display()
        {
            return "42";
        }



    }
}
