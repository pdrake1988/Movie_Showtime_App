using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie_Showtime_App.Core.Models;

namespace Movie_Showtime_App.API_Models
{
    public static class TicketMappingExtension
    {
        public static TicketModel ToApiModel(this Tickets domainItem)
        {
            return new TicketModel
            {
                Id = domainItem.Id,
                TheaterNumber = domainItem.TheaterNumber,
                SeatNumber = domainItem.SeatNumber,
                ShowTime = domainItem.ShowTime,
                MovieId = domainItem.MovieId,
                UserId = domainItem.UserId
            };
        }
        public static Tickets ToDomainModel(this TicketModel apiModel)
        {
            return new Tickets
            {
                Id = apiModel.Id,
                TheaterNumber = apiModel.TheaterNumber,
                SeatNumber = apiModel.SeatNumber,
                MovieId = apiModel.MovieId,
                UserId = apiModel.UserId
            };
        }
        public static IEnumerable<TicketModel> ToApiModels(this IEnumerable<Tickets> domainObjects)
        {
            return domainObjects.Select(t => t.ToApiModel());
        }
        public static IEnumerable<Tickets> ToDomainModels(this IEnumerable<TicketModel> ticketModels)
        {
            return ticketModels.Select(t => t.ToDomainModel());
        }
    }
}