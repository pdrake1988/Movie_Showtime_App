using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public int TheaterNumber { get; set; }
        public string SeatNumber { get; set; }
        public string ShowTime { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}