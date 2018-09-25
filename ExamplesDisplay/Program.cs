using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExamplesDisplay.Examples;

namespace ExamplesDisplay
{



    class Program
    {
        private static string footer
        {
            get
            {
                string footerText = "[x] Exit Application \n";

                if (!mainMenuActive)
                {
                    footerText += "[b] Main Menu";
                }
                return footerText;
            }
        }

        private static bool mainMenuActive = true;
        private static string MainMenu
        {
            get 
            {
                var consoleText = "";

                for (int i = 0; i < ExamplesList.Count; i++)
                {
                    consoleText += $"{i + 1}) {ExamplesList[i].Name}\n";
                }

                return consoleText;

            }
        }

        public static List<IExample> ExamplesList = new List<IExample>()
        {
            new YieldFibo(),
            // new EnumerableExample(),
            // new ListExample(),
            new LinqExample(),
            new ExtensionMethods(),
            new CustomEnumerator()
        };


        public static void WriteToConsole(string consoleText)
        {
            Console.Clear();
            Console.WriteLine(consoleText);
            Console.WriteLine(footer);
        }




        static void Main(string[] args)
        {
            WriteToConsole(MainMenu);
            while (true)
            {
                string key = Console.ReadKey().KeyChar.ToString().ToLower();

                if (key == "x")
                {
                    Environment.Exit(0);
                }
                else
                {
                    KeyChecker(key);
                }

            }
        }

        private static void KeyChecker(string key)
        {
            if (mainMenuActive)
            {
                WriteExample(key);
            }
            else
            {
                ResetMenu(key);
            }
        }

        private static void ResetMenu(string key)
        {
            if (key == "b")
            {
                mainMenuActive = true;
                WriteToConsole(MainMenu);
            }
        }

        private static void WriteExample(string key)
        {
            for (int i = 0; i < ExamplesList.Count; i++)
            {
                var regexp = @"[0-9]{1}";
                bool match = Regex.Match(key, regexp).Success;

                if (match && (int.Parse(key) - 1).ToString() == i.ToString())
                {
                    mainMenuActive = false;
                    WriteToConsole(ExamplesList[i].Display());
                }
            }
        }
    }
}
