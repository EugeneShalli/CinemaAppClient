using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Controllers
{
    public class SessionController : Controller
    {
        private ISessionService SessionService { get; }
        private IFilmService FilmService { get; }
        
        public SessionController(ISessionService sessionService, IFilmService filmService)
        {
            SessionService = sessionService;
            FilmService = filmService;
        }
        public async Task<IActionResult> List()
        {
            return View(await this.SessionService.GetSession());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // return View(await this.SessionService.GetSession());
            return View(await  this.FilmService.GetFilm());
        }

        [HttpPost]
        public async Task<IActionResult> Put(Session session)
        {
            // System.Console.WriteLine(" fdfsdf"  + session.FilmId);
            await this.SessionService.PutSession(session);
            //Console.Out.WriteLine(session);
            return RedirectToAction("List");
        }
        
        
        
        // public async Task<IActionResult> List()
        // {
        //     return View(await this.SessionService.GetSession());
        // }
        // public async Task<IActionResult> List()
        // {
        //     return View(await this.SessionService.GetSession());
        // }
    }
}