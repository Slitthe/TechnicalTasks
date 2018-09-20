using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class ListExample : IExample
    {
        public string StartMessage { get; set; } = "IList Example";
        public string Name { set; get; } = "Demonstrating the abilities offered by an IList";



        public string Display()
        {
            // IList implements ICollection which implements IEnumerable

            /* 
                IList gives the ability to work with index based list and also provided methods for adding/removing/finding items in that list

            Work with a list of items based on a integer index, 0 based

            .RemoveAt
            .Insert
            .IndexOf
        
        

            


             */
            var displayText = "Initial List: ";

            List<string> colorsList = new List<string> { "Red", "Green", "Blue" };
     
            displayText += writeList(colorsList);

            colorsList.Insert(1, "Yellow");
            displayText += descriptionValueFormat("Insert item at index 1", writeList(colorsList));




            colorsList.Remove("Red");
            displayText += descriptionValueFormat("Remove the item at index 2", writeList(colorsList));


            displayText += descriptionValueFormat("Get the index of a specific item \"Green\"", colorsList.IndexOf("Green").ToString());

            displayText += descriptionValueFormat("Access the item by index: [1]", colorsList[1]);


            displayText += "\n";
            return displayText;
        }
        private string descriptionValueFormat(string desc, string val)
        {
            var formattedString = "\n\n";


            formattedString += desc;
            formattedString += "\n------------------";
            formattedString += val;

            return formattedString;
        }
        private string writeList (List<string> listToWrite)
        {
            var returnText = "";
            foreach (var item in listToWrite)
            {
                returnText += item+ ",";
            }

            return returnText;
        }


    }
}
