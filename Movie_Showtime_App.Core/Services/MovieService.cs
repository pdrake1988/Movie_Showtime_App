using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Services
{
    class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieService;
        public MovieService(IMovieRepository movieService)
        {
            _movieService = movieService;
        }
        public Movie Add(Movie newMovie)
        {
            return _movieService.Add(newMovie);
        }

        public Movie Get(int id)
        {
            return _movieService.Get(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieService.GetAll();
        }

        public void Remove(int id)
        {
            _movieService.Remove(id);
        }

        public Movie Update(Movie updatedMovie)
        {
            return _movieService.Update(updatedMovie);
        }
    }
}
