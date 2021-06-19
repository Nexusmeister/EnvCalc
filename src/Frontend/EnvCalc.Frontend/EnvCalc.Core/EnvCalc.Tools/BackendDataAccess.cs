using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EnvCalc.BusinessObjects;
using EnvCalc.BusinessObjects.ProduktManager;
using Serilog.Events;
using Prozess = EnvCalc.BusinessObjects.Prozess;

namespace EnvCalc.Tools
{
    public class BackendDataAccess : IBackendDataAccess
    {
        private readonly HttpClient _client;
        private static readonly string _baseUri = "https://envcalc.z-core.de";

        public static IBackendDataAccess Instance { get; set; }

        public BackendDataAccess()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(_baseUri),
                Timeout = new TimeSpan(1, 0, 0, 25)
            };

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                "ZW52Y2FsYzohb3A3Tl45QWhYbXE0QE9FdXFeTjM5aXU3Wkt5SFEwRmFBZ2dqSVpH");
        }

        public async Task<List<Exchange>> GetAllExchangesAsync()
        {
            var response = await CallWebservice("exchanges", HttpMethod.Get);
            var result = await VerarbeiteResponseAsync<IEnumerable<string>>(response);
            return result!.Select(res => new Exchange { Name = res }).ToList();
        }

        public async Task<List<Prozess>> GetAllProzessberechnungen()
        {
            var response = await CallWebservice("rootEntity", HttpMethod.Get);
            var result = await VerarbeiteResponseAsync<IEnumerable<Prozess>>(response);
            return result.ToList();
        }

        public async Task<List<Produkt>> GetAllProdukteAsync()
        {
            var response = await CallWebservice("products", HttpMethod.Get);
            var result = await VerarbeiteResponseAsync<IEnumerable<Produkt>>(response);
            return result.ToList();
        }

        public async Task<bool> PostProduktAsync(Produkt produkt)
        {
            var response = await _client.PostAsJsonAsync("product", produkt);
            return await VerarbeiteResponseAsync<bool>(response);
        }

        private async Task<HttpResponseMessage> CallWebservice(string endpunkt, HttpMethod methode)
        {
            using var requestMessage = new HttpRequestMessage(methode, endpunkt);
            return await _client.SendAsync(requestMessage);
        }

        public static void ErzeugeInstanz()
        {
            if (Instance is not null)
            {
                throw new ApplicationException($"{nameof(Instance)} wurde bereits für die Applikation instanziiert!");
            }

            Instance = new BackendDataAccess();
        }

        private static async Task<T> VerarbeiteResponseAsync<T>(HttpResponseMessage response)
        {
            if (response.StatusCode is HttpStatusCode.NoContent)
            {
                return default;
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }
            else
            {
                var msg = await response.Content.ReadAsStringAsync();
                Logger.Instanz.WriteLog(msg, LogEventLevel.Error);
                throw new HttpRequestException(msg);
            }
        }
    }
}