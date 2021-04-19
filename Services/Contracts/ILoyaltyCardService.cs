using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaAppClient.Models;

namespace CinemaAppClient.Services.Contracts
{
    public interface ILoyaltyCardService
    {
        Task<IEnumerable<LoyaltyCard>> GetLoyaltyCard();
        Task<LoyaltyCard> GetLoyaltyCard(int id);
        Task<LoyaltyCard> PutLoyaltyCard(LoyaltyCard loyaltycard);
        Task<LoyaltyCard> PatchLoyaltyCard(LoyaltyCard loyaltycard);
    }
}