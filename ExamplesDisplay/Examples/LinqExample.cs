﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"\n           FirstName: {FirstName}, LastName: {LastName}, Gender: {Gender}, Age: {Age}";
        }

    }

    public class LinqExample : IExample
    {
        public LinqExample()
        {
            StartMessage = "LinqExample";
            Name = "Linq methods";

        }

        public string StartMessage { get; set; }

        public string Name { get; set; }

        public string Display()
        {
            // dummy data
            
            // where, select, any, take, skip, first, single
            string consoleText = "";


            var dummyData = new List<Person>()
            {
                new Person { FirstName = "Johnny", LastName = "Bravo", Gender = "M", Age = 20 },
                new Person { FirstName = "Johnny", LastName = "Smith", Gender = "M", Age = 25 },
                new Person { FirstName = "Delia", LastName = "Tonkes", Gender = "F", Age = 30 },
                new Person { FirstName = "Hunter", LastName = "Guntrip", Gender = "M", Age = 19 },
                new Person { FirstName = "Fayina", LastName = "Dungate", Gender = "F", Age = 24 },
                new Person { FirstName = "Lola", LastName = "Porker", Gender = "F", Age = 35 },
                new Person { FirstName = "Dimitri", LastName = "Winsor", Gender = "M", Age = 40 },
                new Person { FirstName = "Dimitri", LastName = "Winsor", Gender = "M", Age = 45 },
                new Person { FirstName = "Dimitri", LastName = "Winsor", Gender = "M", Age = 25 }


            };
            consoleText += descriptionValueFormat("Raw dummy data", DisplayFormatHelpers.writeList<Person>(dummyData) );


            // where
            var femaleOnly = dummyData.Where(person => person.Gender == "F");
            consoleText += descriptionValueFormat("where method, select only Gender = \"F\"", DisplayFormatHelpers.writeList<Person>(femaleOnly));

            // select
            var onlyFirstName = dummyData.Select(person => person.FirstName);
            consoleText += descriptionValueFormat("Select linq method, only first names", DisplayFormatHelpers.writeList<string>(onlyFirstName));


            // any
            var anyJohhnyFirstName = dummyData.Any(person => person.FirstName == "Hunter");
            consoleText += descriptionValueFormat("Any linq method, any person contains FirstName=\"Hunter\"", anyJohhnyFirstName.ToString());

            // take

            var takeExample = dummyData.Take(3);
            consoleText += descriptionValueFormat("Take the first 3 elements only", DisplayFormatHelpers.writeList<Person>(takeExample));


            // skip
            var skipExample = dummyData.Skip(2);
            consoleText += descriptionValueFormat("Skip the first 2 elements", DisplayFormatHelpers.writeList<Person>(skipExample));


            // first
            var firstExample = dummyData.FirstOrDefault(person => person.Gender == "F");
            consoleText += descriptionValueFormat("First female person in the list", firstExample.ToString());



            // single
            var singleExample = dummyData
                                .Where(person => person.Age == 19)
                                .SingleOrDefault();

            consoleText += descriptionValueFormat("Single Linq method (being explicit that you only expect 1 element)", singleExample.ToString());


            // combined example
            var combo = dummyData
                        .Where(p => p.Age >= 20) // filter items
                        .Skip(1) // ignore the first item
                        .Take(2) // only take 2 results from the collection
                        .Select(p => p.FirstName + " " + p.LastName); // return a specific value instead of the whole


            consoleText += descriptionValueFormat("Combo: .Where(p => p.Age >= 20)\n\t.Skip(1)\n\t.Take(2)\n\t.Select(p => p.FirstName + \" \" + p.LastName)", DisplayFormatHelpers.writeList<string>(combo));

            
            return consoleText;
        }

        private string descriptionValueFormat(string desc, string val)
        {
            var formattedString = "\n\n";
            
            formattedString += desc;
            formattedString += "\n------------------";
            formattedString += val;

            return formattedString;
        }

    }
}