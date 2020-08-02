using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}