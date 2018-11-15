using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SOLID_LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> cities = new List<string>()
            {
                "Berlin", "New York", "Los Angeles", "Washington", "San Diego"
            };

            // ReadOnlyCollection<T> implements IList<T>, which indicates an IS A type of relationship
            IList<string> readOnlyCities = new ReadOnlyCollection<string>(cities);

            // both theses method calls should work

            ClearList(cities);

            ClearList(readOnlyCities);
        }

        static void ClearList<T>(IList<T> listOfSomething)
        {
            listOfSomething.Clear();
        }
    }
}
