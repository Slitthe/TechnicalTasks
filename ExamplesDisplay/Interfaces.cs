using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay
{
    public interface IExample
    {
        string StartMessage { get; set; }
        string Name { get; set; }
        string Display();
    }
}
