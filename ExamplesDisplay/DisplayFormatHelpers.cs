using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay
{
    public static class DisplayFormatHelpers
    {
        public static string WriteList<T>(IEnumerable<T> listToWrite)
        {
            var returnText = "";

            foreach (var item in listToWrite)
            {
                returnText += item + ", ";
            }

            return returnText;
        }

        public static string DescriptionValueFormat(string desc, object val)
        {
            var formattedString = "\n\n";

            formattedString += desc;
            formattedString += "\n  ------------------  ";
            formattedString += val.ToString();

            return formattedString;
        }
    }
}

