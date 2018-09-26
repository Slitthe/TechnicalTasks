using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class GenericWhere : IExample
    {
        public string StartMessage { get; set; } = "Calling the custom Where by giving it a type parameter, input list and a delegate";
        public string Name { set; get; } = "LINQ's Where() like generic method";



        public string Display()
        {
            // IEnumerable only allows the given object to be iterated (usually with a foreach)
            var displayText = "";

            IList<int> dummyData = new List<int>() { 0, 6, 7, 1, 8, 9, 4, 7, 7, 1, 5, 8, 2 };
            displayText += DisplayFormatHelpers.DescriptionValueFormat(
                "Initial List",
                DisplayFormatHelpers.WriteList(dummyData)
            );

            var whereResults = Where<int>(dummyData, (i) => i >= 5 );
            displayText += DisplayFormatHelpers.DescriptionValueFormat(
                "Using the Where<T>() method to keep values which are >= 5 only ||  Where<int>(dummyData, (i) => i >= 5 );",
                DisplayFormatHelpers.WriteList(whereResults)
            );

            var whereExtensionResult = dummyData.Where((i) => i >= 5);
            displayText += DisplayFormatHelpers.DescriptionValueFormat(
                "Using the .Where() extension to achieve the same result ||  dummyData.Where((i) => i >= 5);",
                DisplayFormatHelpers.WriteList(whereExtensionResult)
            );




            return displayText;
        }


        public delegate bool WhereDelegate<T>(T item);

        public static ICollection<T> Where<T>(ICollection<T> collectionObj, WhereDelegate<T> checker)
        {
            int matches = 0;
            T[] results;
            foreach (T item in collectionObj)
            {
                var checkResult = checker(item);
                if (checkResult)
                {
                    matches++;
                }
            }

            int index = 0;
            results = new T[matches];
            foreach (T item in collectionObj)
            {
                if (checker(item))
                {
                    results[index] = item;
                    index++;
                }
            }

            return results;
        }

    }

    public static class WhereExtensionMethod
    {

        public delegate bool WhereDelegate<T>(T item);

        public static ICollection<T> Where<T>(this ICollection<T> collectionObj, WhereDelegate<T> checker)
        {
            int matches = 0;
            T[] results;
            foreach (T item in collectionObj)
            {
                var checkResult = checker(item);
                if (checkResult)
                {
                    matches++;
                }
            }

            int index = 0;
            results = new T[matches];

            foreach (T item in collectionObj)
            {
                if (checker(item))
                {
                    results[index] = item;
                    index++;
                }
            }

            return results;
        }
    }

}
