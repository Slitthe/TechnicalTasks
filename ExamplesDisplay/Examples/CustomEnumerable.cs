using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class CustomEnumerator : IExample
    {
        public string StartMessage { get; set; } = "Custom IEnumerable and iterating";
        public string Name { set; get; } = "Creating a random number generator using by implemention the IEnumerable interface to a class";



        public string Display()
        {
            // IEnumerable only allows the given object to be iterated (usually with a foreach)
            var displayText = "";

            IEnumerable enumClass = new RandomNumbers(1, 10, 5);
            List<int> randNums = new List<int>(5);
            foreach (int randNum in enumClass)
            {
                randNums.Add(randNum);
            }
            displayText += DisplayFormatHelpers.descriptionValueFormat
            (
                "Iterating over the custom iterable class using a foreach",
                DisplayFormatHelpers.writeList(randNums)
            );

            Console.WriteLine("\n\n\n");
            IEnumerable enumClass2 = new RandomNumbers(1, 3, 10);

            List<int> randNums2 = new List<int>(5);
      
            IEnumerator enumClass2Enumerator = enumClass2.GetEnumerator();
            while (enumClass2Enumerator.MoveNext())
            {
                randNums2.Add((int)enumClass2Enumerator.Current);
            }
            displayText += DisplayFormatHelpers.descriptionValueFormat
            (
                "Iterating over the custom iterable class using a while loop",
                DisplayFormatHelpers.writeList(randNums2)
            );

            return displayText;
        }

    }

    public class RandomNumbers : IEnumerable
    {
        public RandomNumbers(int start, int end, int length)
        {
            this.Start = start;
            this.End = end;
            this.Length = length;
        }

        public int GetNext
        {
            get
            {
                return rand.Next(Start, End);
            }
        }
        public Random rand = new Random();

        public int Index = -1;
        public int Start { get; private set; }
        public int End { get; private set; }
        public int Length { get; private set; }

        // Generates the specific enumerator for this type
        public IEnumerator GetEnumerator()
        {
            return new RandonNumberEnumerator(this);
        }
    }

    public class RandonNumberEnumerator : IEnumerator
    {
        public RandomNumbers ClassReference { get; private set; }

        public object Current
        {
            get
            {
                return ClassReference.GetNext;
            }
        }

        public RandonNumberEnumerator(RandomNumbers classReference)
        {
            ClassReference = classReference;
        }


        public bool MoveNext()
        {
            ClassReference.Index++;
            return ClassReference.Index < ClassReference.Length;
        }

        public void Dispose()
        {
            return;
        }
        public void Reset()
        {
            ClassReference.Index = -1;
            return;
        }

    }
}
