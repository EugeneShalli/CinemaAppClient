using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaAppClient.Models;

namespace CinemaAppClient.Services.Contracts
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetFilm();
        Task<Film> GetFilm(int id);
        Task<Film> PutFilm(Film film);
        Task<Film> PatchFilm(Film film);
    }
}