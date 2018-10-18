using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExamplesDisplay.Examples;

namespace ExamplesDisplay
{



    class Program
    {
        private static string Footer
        {
            get
            {
                string footerText = "\n\n[x] Exit Application \n";

                if (!_mainMenuActive)
                {
                    footerText += "[b] Main Menu";
                }
                return footerText;
            }
        }

        private static bool _mainMenuActive = true;
        private static string MainMenu
        {
            get 
            {
                var consoleText = "";

                for (int i = 0; i < ExamplesList.Count; i++)
                {
                    consoleText += $"{ExamplesList[i].Item3}) {ExamplesList[i].Item1.Name}\n";
                }
                return consoleText;

            }
        }

        public static List<Tuple<IExample, ConsoleKey, char>> ExamplesList = new List<Tuple<IExample, ConsoleKey, char>>()
        {
            new Tuple<IExample, ConsoleKey, char>(new YieldFibo(), ConsoleKey.D1, '1'),
            new Tuple<IExample, ConsoleKey, char>(new LinqExample(), ConsoleKey.D2, '2'),
            new Tuple<IExample, ConsoleKey, char>(new ExtensionMethods(), ConsoleKey.D3, '3'),
            new Tuple<IExample, ConsoleKey, char>(new CustomEnumerator(), ConsoleKey.D4, '4'),
            new Tuple<IExample, ConsoleKey, char>(new IListExample(), ConsoleKey.D5, '5'),
            new Tuple<IExample, ConsoleKey, char>(new GenericWhere(), ConsoleKey.D6, '6'),
            new Tuple<IExample, ConsoleKey, char>(new GenericCsvConvertor(), ConsoleKey.D7, '7'),
            new Tuple<IExample, ConsoleKey, char>(new GenericToArray(), ConsoleKey.D8, '8'),
            new Tuple<IExample, ConsoleKey, char>(new ToStringExample(), ConsoleKey.D9, '9'),
            new Tuple<IExample, ConsoleKey, char>(new BoxingUnboxingExample(), ConsoleKey.A, 'a'),
            new Tuple<IExample, ConsoleKey, char>(new ExplicitInterfaceImplementation(), ConsoleKey.B, 'b'),
            new Tuple<IExample, ConsoleKey, char>(new ValueTuplesExample(), ConsoleKey.C, 'c'),
            new Tuple<IExample, ConsoleKey, char>(new MultipleThreadsCalculateExample(), ConsoleKey.D, 'd')

        };


        public static void WriteToConsole(string startMessage, string consoleText)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine(startMessage);
            Console.WriteLine(consoleText);
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(Footer);
        }
        public static void WriteToConsole(string consoleText)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine(consoleText);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Footer);
        }




        static void Main(string[] args)
        {
            WriteToConsole(MainMenu);
            while (true)
            {
                // use enums instead of strings, refactor
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }
                else
                {
                    KeyChecker(key);
                }

            }
        }

        private static void KeyChecker(ConsoleKey key)
        {
            if (_mainMenuActive)
            {
                WriteExample(key);
            }
            else
            {
                ResetMenu(key);
            }
        }

        private static void ResetMenu(ConsoleKey key)
        {
            if (key == ConsoleKey.B)
            {
                _mainMenuActive = true;
                WriteToConsole(MainMenu);
            }
        }

        private static void WriteExample(ConsoleKey key)
        {
            foreach (var example in ExamplesList)
            {
                // if the key is the exames list
                if (key == example.Item2)
                {
                    _mainMenuActive = false;
                    WriteToConsole(example.Item1.StartMessage, example.Item1.Display());
                }
            }
        }
    }
}
