﻿using System;
using System.Collections.Generic;
using System.Text;
using Movie_Showtime_App.Core.Models;
using Movie_Showtime_App.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Movie_Showtime_App.Infrastructure.Data
{
    class TicketRepository : ITicketRepository
    {
        private readonly DbContext _dbContext;
        public TicketRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Tickets Add(Tickets newTicket)
        {
            _dbContext.Tickets.Add(newTicket);
            _dbContext.SaveChanges();
            return newTicket;
        }

        public Tickets Get(int id)
        {
            return _dbContext.Tickets
                    .FirstOrDefault(t => t.TicketId == id);
        }

        public IEnumerable<Tickets> GetAll()
        {
            return _dbContext.Tickets
                    .ToList();
        }

        public void Remove(int id)
        {
            var deleteTicket = _dbContext.Tickets.Find(id);
            if(deleteTicket != null)
            {
                _dbContext.Tickets.Remove(deleteTicket);
                _dbContext.SaveChanges();
            }
        }

        public Tickets Update(Tickets updatedTicket)
        {
            var selectedTicket = _dbContext.Tickets.Find(updatedTicket.TicketId);
            if (selectedTicket == null) return null;
            _dbContext.Entry(selectedTicket)
                .CurrentValues
                .SetValues(updatedTicket);
            return selectedTicket;
        }
    }
}