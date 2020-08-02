using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Showtime_App.API_Models
{
    public static class MovieMappingExtension
    {
        public static MovieModel ToApiModel(this Movie domainItem)
        {
            return new MovieModel
            {
                Id = domainItem.Id,
                MovieTitle = domainItem.MovieTitle,
                Rating = domainItem.Rating
            };
        }
        public static Movie ToDomainModel(this MovieModel apiModel)
        {
            return new Movie
            {
                Id = apiModel.Id,
                MovieTitle = apiModel.MovieTitle,
                Rating = apiModel.Rating
            };
        }
        public static IEnumerable<MovieModel> ToApiModels(this IEnumerable<Movie> domainObjects)
        {
            return domainObjects.Select(t => t.ToApiModel());
        }
        public static IEnumerable<Movie> ToDomainModels(this IEnumerable<MovieModel> MovieModels)
        {
            return MovieModels.Select(t => t.ToDomainModel());
        }
    }
}
