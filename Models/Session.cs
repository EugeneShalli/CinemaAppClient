using System;

namespace CinemaAppClient.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public string Room { get; set; }

        public int? FilmId { get; set; }
    }
}