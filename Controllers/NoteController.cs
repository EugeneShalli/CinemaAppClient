using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Controllers
{
    public class NoteController : Controller
    {
        // GET
        private INoteService NoteService { get; }
        private IVisitorService VisitorService { get; }
        private ISessionService SessionService { get; }
        private IFilmService FilmService { get; }
        
        public NoteController(INoteService noteService, IVisitorService visitorService, ISessionService sessionService, IFilmService filmService)
        {
            NoteService = noteService;
            VisitorService = visitorService;
            SessionService = sessionService;
            FilmService = filmService;
        }

        public async Task<IActionResult> Notes()
        {
            
            return View(await this.NoteService.GetNote());
        }

        [HttpGet]
        public async Task<IActionResult> AddNote()
        {
            return View(new HelpObjects(await  this.VisitorService.GetVisitor(),
                await  this.SessionService.GetSession(),
                await this.FilmService.GetFilm()));
        }
        [HttpPost]
        public async Task<IActionResult> Put(Note note)
        {
            await this.NoteService.PutNote(note);
            //Console.Out.WriteLine(note);
            return RedirectToAction("Notes");
        }
    }
}