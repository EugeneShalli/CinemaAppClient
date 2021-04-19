using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Services.Implementations
{
    public class SessionService: ISessionService
    {
        private HttpClient HttpClient { get; }
        
        public SessionService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Session>> GetSession()
        {
            using var response = await this.HttpClient.GetAsync("api/session");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Session>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Session> GetSession(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/session/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Session>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Session> PutSession(Session session)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(session), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/session",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Session>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Session> PatchSession(Session session)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(session), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/session",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Session>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}