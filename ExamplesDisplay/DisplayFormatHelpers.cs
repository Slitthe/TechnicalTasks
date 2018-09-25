using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay
{
    public static class DisplayFormatHelpers
    {
        public static string writeList<T>(IEnumerable<T> listToWrite)
        {
            var returnText = "";

            foreach (var item in listToWrite)
            {
                returnText += item + ", ";
            }

            return returnText;
        }

        public static string descriptionValueFormat(string desc, string val)
        {
            var formattedString = "\n\n";

            formattedString += desc;
            formattedString += "\n------------------";
            formattedString += val;

            return formattedString;
        }
    }
}

