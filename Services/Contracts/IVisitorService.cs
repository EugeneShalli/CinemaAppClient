using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaAppClient.Models;

namespace CinemaAppClient.Services.Contracts
{
    public interface IVisitorService
    {
        Task<IEnumerable<Visitor>> GetVisitor();
        Task<Visitor> GetVisitor(int id);
        Task<Visitor> PutVisitor(Visitor visitor);
        Task<Visitor> PatchVisitor(Visitor visitor);
    }
}