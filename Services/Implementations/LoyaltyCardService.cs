using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Services.Implementations
{
    public class LoyaltyCardService:ILoyaltyCardService
    {
        private HttpClient HttpClient { get; }
        
        public LoyaltyCardService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<LoyaltyCard>> GetLoyaltyCard()
        {
            using var response = await this.HttpClient.GetAsync("api/loyaltycard");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<LoyaltyCard>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<LoyaltyCard> GetLoyaltyCard(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/loyaltycard/" + id);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<LoyaltyCard>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<LoyaltyCard> PutLoyaltyCard(LoyaltyCard loyaltycard)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(loyaltycard), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/loyaltycard",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<LoyaltyCard>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<LoyaltyCard> PatchLoyaltyCard(LoyaltyCard loyaltycard)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(loyaltycard), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/loyaltycard",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<LoyaltyCard>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}