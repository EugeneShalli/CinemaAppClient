using System.Collections.Generic;

namespace CinemaAppClient.Models
{
    public class HelpObjects
    {
        
        public IEnumerable<Visitor> Visitors;
        public IEnumerable<Session> Sessions;
        public IEnumerable<Film> Films;

        public HelpObjects(IEnumerable<Visitor> visitors, IEnumerable<Session> sessions, IEnumerable<Film> film)
        {
            Visitors = visitors;
            Sessions = sessions;
            Films = film;
        }
    }
}