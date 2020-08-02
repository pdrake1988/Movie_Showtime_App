using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Services
{
    public interface ITicketService
    {
        Tickets Add(Tickets newTicket);
        Tickets Update(Tickets updatedTicket);
        Tickets Get(int id);
        IEnumerable<Tickets> GetAll();
        void Remove(int id);
    }
}