using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Showtime_App.API_Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Rating { get; set; }
        public IEnumerable<TicketModel> Tickets { get; set; }
    }
}
