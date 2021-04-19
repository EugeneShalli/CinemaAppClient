using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Controllers
{
    public class LoyaltyCardController : Controller
    {
        // GET
        private ILoyaltyCardService LoyaltyCardService { get; }
        
        public LoyaltyCardController(ILoyaltyCardService loyaltycardService)
        {
            LoyaltyCardService = loyaltycardService;
        }
        public async Task<IActionResult> ListLoyaltyCards()
        {
            return View(await this.LoyaltyCardService.GetLoyaltyCard());
        }

      
        [HttpPost]
        public async Task<IActionResult> Put(LoyaltyCard loyaltycard)
        {
            await this.LoyaltyCardService.PutLoyaltyCard(loyaltycard);
            //Console.Out.WriteLine(loyaltycard);
            return RedirectToAction("ListLoyaltyCards");
        }

    }
}