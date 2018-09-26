using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamplesDisplay.Examples
{
    class GenericCsvConvertor : IExample
    {
        public string StartMessage { get; set; } = "";
        public string Name { set; get; } = "Object fields To CSV convertor (using generics)";



        public string Display()
        {
            var displayText = "";

            IList<Car> carList = new Car[]
            {
                new Car() { Brand = "Toyota", Make = "Prius" },
                new Car() { Brand = "Subaru", Make = "Impreza" },
                new Car() { Brand = "Mitsubishi", Make = "Lancer" },
                new Car() { Brand = "Skoda", Make = "Octavia" },
                new Car() { Brand = "VW", Make = "Golf" },
                new Car() { Brand = "Nissan", Make = "GTR" }
            };

            displayText += DisplayFormatHelpers.DescriptionValueFormat
            (
                "Raw object (using fields)",
                DisplayFormatHelpers.WriteList(carList)
            );

            var convertor = new ObjectListToCsv<Car>(carList);
            displayText += DisplayFormatHelpers.DescriptionValueFormat
            (
                "Object list to CSV format",
                convertor.ToCsv()
            );



            return displayText;
        }
        class Car
        {
            public string Brand;
            public string Make;

            public override string ToString()
            {
                return $"{{ Brand = {Brand}, Make = {Make} }}\n";
            }
        }


        public class ObjectListToCsv<T> where T : class
        {
            IList<T> objList;
            public ObjectListToCsv(IList<T> inputList)
            {
                if (inputList.Count <= 0)
                {
                    throw new ArgumentException();
                }
                objList = inputList;


            }

            public string ToCsv()
            {
                string header = getHeaders();
                string body = string.Join('\n', constructBody());

                string csvText = header + '\n' + body;

                return csvText;
            }
            private string getHeaders()
            {
                var csvHeaders = new List<string>();
                var fields = objList[0].GetType().GetFields();

                foreach (var field in fields)
                {

                    csvHeaders.Add(field.Name);
                }

                string headerJoined = string.Join(',', csvHeaders);

                return headerJoined;

            }

            private IList<string> constructBody()
            {
                var csvBody = new List<string>();
                IList<string> currentItemLine = new List<string>();

                var fields = objList[0].GetType().GetFields();
                foreach (T item in objList)
                {
                    currentItemLine.Clear();

                    foreach (var field in fields)
                    {
                        var value = field.GetValue(item);
                        currentItemLine.Add(value.ToString());
                    }


                    csvBody.Add(string.Join(',', currentItemLine));
                }


                return csvBody;
            }
        }

    }

}
