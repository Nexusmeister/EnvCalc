using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EnvCalc.BusinessObjects;
using Serilog.Events;

namespace EnvCalc.Tools
{
    public class BackendDataAccess : IBackendDataAccess
    {
        private readonly HttpClient _client;
        private static readonly string _baseUri = "http://envcalc.z-core.de";

        public static IBackendDataAccess Instance { get; set; }

        public BackendDataAccess()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(_baseUri),
                Timeout = new TimeSpan(0, 0, 0, 10)
            };
        }

        public async Task<List<Exchange>> GetAllExchangesAsync()
        {
            var response = await _client.GetAsync("exchanges");
            if (response.StatusCode is HttpStatusCode.NoContent)
            {
                return default;
            }
            if (response.IsSuccessStatusCode)
            {
                var listeResult = await response.Content.ReadFromJsonAsync<List<string>>();
                return listeResult!.Select(res => new Exchange {Name = res}).ToList();
            }
            else
            {
                var msg = await response.Content.ReadAsStringAsync();
                Logger.Instanz.WriteLog(msg, LogEventLevel.Error);
                throw new Exception(msg);
            }
        }

        public async Task<List<ProzessRoot>> GetAllProzessberechnungen()
        {
            var response = await _client.GetAsync("rootEntity");
            if (response.StatusCode is HttpStatusCode.NoContent)
            {
                return default;
            }

            if (response.IsSuccessStatusCode)
            {
                var listeResult = await response.Content.ReadFromJsonAsync<List<ProzessRoot>>();
                return listeResult;
            }
            else
            {
                var msg = await response.Content.ReadAsStringAsync();
                Logger.Instanz.WriteLog(msg, LogEventLevel.Error);
                throw new Exception(msg);
            }
        }

        public static void ErzeugeInstanz()
        {
            if (Instance is not null)
            {
                throw new ApplicationException($"{nameof(Instance)} wurde bereits für die Applikation instanziiert!");
            }

            Instance = new BackendDataAccess();
        }
    }
}