using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using VismaSummitDemo2015.Properties;

namespace VismaSummitDemo2015
{
    internal static class Controllers
    {
        internal const string Token = "security/api/v1/token";
        internal const string Help = "controller/api/v1/help";
        internal const string Customer = "controller/api/v1/customer";
        internal const string CustomerInvoice = "controller/api/v1/customerinvoice";
    }

    internal static class VismaNetDemo
    {
        internal static string Token
        {
            get { return Settings.Default.Token; }
            set
            {
                Settings.Default.Token = value;
                Settings.Default.Save();
            }
        }

        internal static string CompanyId
        {
            get { return Settings.Default.CompanyId; }
            set
            {
                Settings.Default.CompanyId = value;
                Settings.Default.Save();
            }
        }

        private static RestClient CreateRestClient()
        {
            var client = new RestClient("https://integration.visma.net/API/");
            client.AddDefaultHeader("ipp-application-type", "Visma.net Financials");

            if (!string.IsNullOrEmpty(Token))
                client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Token, "Bearer");

            if (!string.IsNullOrEmpty(CompanyId))
                client.AddDefaultHeader("ipp-company-id", CompanyId);

            return client;
        }

        public static void Autenticate()
        {
            var userdata = new
            {
                email = Helpers.RequestInput("email"),
                password = Helpers.RequestInput("password", Helpers.GetMaskedPassword)
            };
            var client = CreateRestClient();
            var request = new RestRequest(Controllers.Token, Method.POST);
            request.AddJsonBody(userdata);
            var response = client.Execute<Dictionary<string, string>>(request);
            if (response.Data.ContainsKey("token"))
            {
                Token = response.Data["token"];
                CompanyId = Helpers.RequestInput("CompanyId");
                Console.WriteLine($"Token: {Token}, CompanyId: {CompanyId}");
            }
            else
            {
                Console.WriteLine("Brukernavn og/eller passord var feil.");
            }
        }

        public static void DownloadHelpFile()
        {
            Console.WriteLine("Laster ned og åpner hjelpefilen");
            var client = CreateRestClient();
            var request = new RestRequest(Controllers.Help);
            var response = client.Execute(request);
            var tmp = Path.GetTempFileName() + ".html";
            File.WriteAllText(tmp, response.Content);
            Process.Start(tmp);
        }

        public static void GetCustomers()
        {
            Console.WriteLine("Henter alle registrerte kunder");
            var client = CreateRestClient();
            var request = new RestRequest(Controllers.Customer);
            var response = client.Execute<List<Customer>>(request);
            foreach (var customer in response.Data)
            {
                Console.WriteLine($"{customer.number}: {customer.name}");
            }
        }

        public static void CreateCustomer()
        {
            var client = CreateRestClient();
            var request = new RestRequest(Controllers.Customer, Method.POST);
            request.AddJsonBody(new
            {
                name = new DtoValue<string>(Helpers.RequestInput("Navn"))
            });

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("Kunden ble opprettet.");
            }
            else
            {
                Console.WriteLine("Kunden ble ikke opprettet.");
            }
        }

        public static void Logout()
        {
            Token = null;
            CompanyId = null;
            Console.WriteLine("Du er logget ut og må autentisere på nytt");
        }
    }

    public class DtoValue<T>
    {
        public DtoValue(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}