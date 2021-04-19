using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaAppClient.Models;

namespace CinemaAppClient.Services.Contracts
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> GetSession();
        Task<Session> GetSession(int id);
        Task<Session> PutSession(Session session);
        Task<Session> PatchSession(Session session);
    }
}