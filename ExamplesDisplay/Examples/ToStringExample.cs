using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ExamplesDisplay.Examples
{
    public class ToStringExample : IExample
    {
        public ToStringExample()
        {
            StartMessage = ""; ;
            Name = "Custom ToString() implementation";
        }
        public string StartMessage { get; set; }
        public string Name { get; set; }
        public string Display()
        {
            string consoleText = "";

            var list = new List<object>
            {
                new Something("val one", "val two"),
                2,
                false,
                3.2,
                3.2f,
                3.2f,
                's',
                "something",
                new StructExaple("struct val one", "struct val two")
            };
            IEnumerable<object> items = new EnumerableExample<object>(list);


            consoleText += DisplayFormatHelpers.DescriptionValueFormat
            (
                "Raw list: ",
                DisplayFormatHelpers.WriteList(list)
            );

            consoleText += DisplayFormatHelpers.DescriptionValueFormat
            (
                "Printing the above list using the custom .ToString(): ",
                items
            );



            return consoleText;
        }

    }


    //public class EnumerableClass : IEnumerable<string>
    //{
    //    private readonly IEnumerable<string> _list = new List<string>() { "One", "Two", "Three" };
    //    public IEnumerator<string> GetEnumerator()
    //    {
    //        return _list.GetEnumerator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return _list.GetEnumerator();
    //    }

    //    public override string ToString()
    //    {
    //        string combined = string.Join("\n", _list);

    //        Console.WriteLine("sad");
    //        return combined;
    //    }
    //}

    //public class EnumerableExample<T> : IEnumerable<T>
    //{
    //    public EnumerableExample()
    //    {
    //        List = new List<T>();
    //    }
    //    private IEnumerable<T> List { get; set; }

    //    //public void Add(T item)
    //    //{
    //    //    var listEx = (IList<T>) List;
    //    //    listEx.Add(item);
    //    //}

    //    public void Something()
    //    {
    //        return;
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        return List.GetEnumerator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return List.GetEnumerator();
    //    }

    //    public override string ToString()
    //    {
    //        string combined = string.Join("\n", List);

    //        return combined;
    //    }
    //}

    public class EnumerableExample<T> : IEnumerable<T>
    {
        public EnumerableExample(IList<T> list)
        {
            List = list;
        }
        private IList<T> List { get; }

        public void Add(T item)
        {
            List.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public override string ToString()
        {
            var writeString = new List<string>();

            foreach (var item in List)
            {
                Type itemType = item.GetType();

                if (itemType.IsPrimitive)
                {
                    writeString.Add(item.ToString());
                }
                else
                {
                    try
                    {
                        var props = ReflectionHelpers.GetPropertiesList(item);
                        writeString.Add(ReflectionHelpers.FormatPropertiesList(props));
                    }
                    catch (TargetParameterCountException)
                    {
                        writeString.Add(item.ToString());
                    }

                }
            }

            string combined = string.Join('\n', writeString);

            return combined;
        }
    }


    public static class ReflectionHelpers
    {
        public static Dictionary<string, object> GetPropertiesList(object obj)
        {
            var returnObjList = new Dictionary<string, object>();

            IList<object> props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                returnObjList.Add(prop.Name, prop.GetValue(obj));
            }

            return returnObjList;
        }

        public static string FormatPropertiesList(Dictionary<string, object> propsList)
        {
            var stringBuilder = new StringBuilder();

            foreach (var prop in propsList)
            {
                stringBuilder.Append($"{prop.Key} : \"{prop.Value}\", ");
            }

            return stringBuilder.ToString();
        }

    }

    public struct StructExaple
    {
        public StructExaple(string one, string two)
        {
            One = one;
            Two = two;
        }

        public string One { get; set; }
        public string Two { get; set; }
    }
    public class Something
    {
        public string PropOne { get; set; }
        public string PropTwo { get; set; }

        public Something(string propOne, string propTwo)
        {
            PropOne = propOne;
            PropTwo = propTwo;
        }
    }
}