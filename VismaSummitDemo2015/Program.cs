using System;
using System.Collections.Generic;

namespace VismaSummitDemo2015
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Visma Summit 2015 - Demo Visma.Net API");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\r\nCopyright ON IT AS {DateTime.UtcNow.Year} (post@on-it.no)");
            Console.ForegroundColor = ConsoleColor.Gray;

            var quit = false;
            var actions = new Dictionary<string, Action>
            {
                ["a"] = VismaNetDemo.Autenticate,
                ["h"] = VismaNetDemo.DownloadHelpFile,
                ["x"] = VismaNetDemo.Logout,
                ["c"] = VismaNetDemo.GetCustomers,
                ["n"] = VismaNetDemo.CreateCustomer,
                ["q"] = () => quit = true,
                ["?"] = PrintHelpMenu
            };

            PrintHelpMenu();

            do
            {
                Console.Write("> ");
                var input = Console.ReadKey();
                Console.WriteLine();
                var key = input.KeyChar.ToString().ToLowerInvariant();
                if (actions.ContainsKey(key))
                    actions[key].Invoke();
                else
                    Console.WriteLine("Ukjent valg. Vennligst prøv igjen.");
            } while (!quit);
        }

        private static bool IsTokenAndCompanyIdProvided()
        {
            //return false;
            return !string.IsNullOrEmpty(VismaNetDemo.Token) &&
                   !string.IsNullOrEmpty(VismaNetDemo.CompanyId);
        }

        private static void PrintHelpMenu()
        {
            Console.WriteLine($"\r\nTilgjengelige valg:\r\n");
            Console.WriteLine("[a] Autentiser bruker");
            if (IsTokenAndCompanyIdProvided())
            {
                Console.WriteLine("[h] Last inn hjelpefilen for APIet");
                Console.WriteLine("[c] List ut kunder");
                Console.WriteLine("[n] Opprett ny kunde");
                Console.WriteLine("[x] Logg ut (slett token)");
            }
            Console.WriteLine($"\r\n[?] Denne menyen");
            Console.WriteLine($"[q] Avslutt program\r\n");
        }
    }
}