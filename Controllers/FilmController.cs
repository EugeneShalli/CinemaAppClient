using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Controllers
{
    public class FilmController:Controller
    {
        private IFilmService FilmService { get; }
        
        public FilmController(IFilmService filmService)
        {
            FilmService = filmService;
        }
        public async Task<IActionResult> ListFilms()
        {
            return View(await this.FilmService.GetFilm());
        }
        public async Task<IActionResult> InfoFilm(int id)
        {
            return View(await this.FilmService.GetFilm(id));
        }
        
        public async Task<IActionResult> AddFilm()
        {
            return View(await this.FilmService.GetFilm());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Film film)
        {
            await this.FilmService.PutFilm(film);
            //Console.Out.WriteLine(session);
            return RedirectToAction("ListFilms");
        }
    }
}