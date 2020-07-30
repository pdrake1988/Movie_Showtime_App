using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Rating { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
