using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Showtime_App.API_Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int TheaterNumber { get; set; }
        public string SeatNumber { get; set; }
        public string ShowTime { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
