using f1management.Domain.API;
using f1management.Domain.API.Constructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace f1management.APIs
{
    public class ErgastApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Root> GetDriverStandingsAsync()
        {
            var url = "https://ergast.com/api/f1/current/driverStandings.json";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Root>(json, options);
        }

        public async Task<ConstructorStandingsRoot> GetConstructorStandingsAsync()
        {
            var url = "https://ergast.com/api/f1/current/constructorStandings.json";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ConstructorStandingsRoot>(json, options);
        }
    }
}
