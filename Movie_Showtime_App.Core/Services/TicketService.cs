using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Services
{
    class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepo;
        public TicketService(ITicketRepository ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }
        public Tickets Add(Tickets newTicket)
        {
            return _ticketRepo.Add(newTicket);
        }

        public IEnumerable<Tickets> GetAll()
        {
            return _ticketRepo.GetAll();
        }

        public Tickets Get(int id)
        {
            return _ticketRepo.Get(id);
        }

        public void Remove(int id)
        {
            _ticketRepo.Remove(id);
        }

        public Tickets Update(Tickets updatedTicket)
        {
            return _ticketRepo.Update(updatedTicket);
        }
    }
}
