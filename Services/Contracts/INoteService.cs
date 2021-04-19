using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaAppClient.Models;

namespace CinemaAppClient.Services.Contracts
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNote();
        Task<Note> GetNote(int id);
        Task<Note> PutNote(Note note);
        Task<Note> PatchNote(Note note);
    }
}