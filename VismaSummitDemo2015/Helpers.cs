using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace VismaSummitDemo2015
{
    internal static class Helpers
    {
        public static string RequestInput(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }

        public static string RequestInput(string message, Func<string> action)
        {
            Console.Write($"{message}:");
            return action.Invoke();
        }

        public static void OpenInNotepad(string text)
        {
            var filename = $"{Path.GetTempFileName()}.txt";
            File.WriteAllText(filename, text);
            Process.Start(filename);
        }

        public static string GetMaskedPassword()
        {
            var sb = new StringBuilder();
            while (true)
            {
                var cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }
    }
}