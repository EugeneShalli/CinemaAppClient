using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Services.Implementations
{
    public class VisitorService:IVisitorService
    {
        private HttpClient HttpClient { get; }
        
        public VisitorService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Visitor>> GetVisitor()
        {
            using var response = await this.HttpClient.GetAsync("api/visitor");
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Visitor>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Visitor> GetVisitor(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/visitor/" + id);
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Visitor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Visitor> PutVisitor(Visitor visitor)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(visitor), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/visitor",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Visitor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Visitor> PatchVisitor(Visitor visitor)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(visitor), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/visitor",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Visitor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}