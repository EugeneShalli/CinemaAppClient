using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Services.Implementations
{
    public class FilmService:IFilmService
    {
        private HttpClient HttpClient { get; }
        
        public FilmService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Film>> GetFilm()
        {
            using var response = await this.HttpClient.GetAsync("api/film");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Film>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Film> GetFilm(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/film/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Film> PutFilm(Film film)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(film), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/film",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Film> PatchFilm(Film film)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(film), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/film",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}