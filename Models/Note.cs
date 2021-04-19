using System;

namespace CinemaAppClient.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int VisitorId { get; set; }
        
        public int? FilmId { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}