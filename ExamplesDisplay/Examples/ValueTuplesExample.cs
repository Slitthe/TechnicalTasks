using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class ValueTuplesExample : IExample
    {
        public ValueTuplesExample()
        {
            StartMessage = "";
            Name = "Value tuple";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            (string, int) nameAgeNormalValueTuple = GetNameAndAge();
           consoleText += $"Value type of a named tuple, isValueType: {GetType().IsValueType}\n\n";

            // defining a named tuple data type and storing the results from the method which also returns a named tuple
            (string name, int age) nameAgeNamedTuple = GetNameAndAgeWithNamedValueTuples();
            

            // accessing the members directly by their name
            consoleText += "Accesing the members of a named tuple directly\n";
            consoleText += nameAgeNamedTuple.name;
            consoleText += '\n';
            consoleText += nameAgeNamedTuple.age;



            // deconstructing a value tuple into local variables
            var (name, age) = GetNameAndAgeWithNamedValueTuples();
            consoleText += $"\n\nNamed tuple deconstructed: \n{name}\n{age}";

            return consoleText;
        }

        public static (string, int) GetNameAndAge()
        {
            // (string, int) equivalent to ValueTuple<string, int>
            (string, int) nameAndAge = ("Jon Snow", 21);

            return nameAndAge;
        }

        public static (string name, int age) GetNameAndAgeWithNamedValueTuples()
        {
            (string name, int age) nameAndAge = ("Sansa Stark", 20);

            return nameAndAge;
        }
    }


}
