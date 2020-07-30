using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}