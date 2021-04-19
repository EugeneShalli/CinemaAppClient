using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaAppClient.Models;
using CinemaAppClient.Services.Contracts;

namespace CinemaAppClient.Controllers
{
    public class VisitorController : Controller
    {
        private IVisitorService VisitorService { get; }
        private ILoyaltyCardService LoyaltyCardService { get; }
        public VisitorController(IVisitorService visitorService, ILoyaltyCardService loyaltycardService)
        {
            VisitorService = visitorService;
            LoyaltyCardService = loyaltycardService;
        }
        public async  Task<IActionResult> List()
        {
            return View(await this.VisitorService.GetVisitor());
        }
      
        public async Task<IActionResult> AddVisitor()
        {
            return View(await  this.LoyaltyCardService.GetLoyaltyCard());
        }

        [HttpPost]
        public async Task<IActionResult> Put(Visitor visitor)
        {
            System.Console.WriteLine(" fdfsdf"  + visitor.LoyaltyCardId);
            await this.VisitorService.PutVisitor(visitor);
            return RedirectToAction("List");
        }
    }
}