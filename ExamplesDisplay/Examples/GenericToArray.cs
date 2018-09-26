using System.Collections.Generic;

namespace ExamplesDisplay.Examples
{
    public static class ExtensionMethodCustom
    {
        public static T[] ToArray<T>(this ICollection<T> collection)
        {
            T[] arrayResult = new T[collection.Count];

            int index = 0;

            foreach (var item in collection)
            {
                arrayResult[index] = item;
                index++;
            }

            return arrayResult;

        }

    }
    class GenericToArray : IExample
    {
        public string StartMessage { get; set; } = "Used on ICollection<T> types";
        public string Name { set; get; } = "ToArray<T>() method (extension method with a type parameter)";


        public string Display()
        {
            var displayText = "";

            var someList = new List<string> { "one", "two", "three", "four", "five" };

            displayText += DisplayFormatHelpers.DescriptionValueFormat
            (
                 "List, type: " + someList.GetType().ToString(),
                 DisplayFormatHelpers.WriteList(someList)
            );

            string[] someListArray = someList.ToArray();

            displayText += DisplayFormatHelpers.DescriptionValueFormat
            (
                 "List to array, type: " + someListArray.GetType().ToString(),
                 DisplayFormatHelpers.WriteList<string>(someListArray)
            );

            return displayText;
        }

    }

    
}
