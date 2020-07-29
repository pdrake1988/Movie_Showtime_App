using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Services
{
    interface IMovieService
    {
        Movie Add(Movie newMovie);
        Movie Update(Movie updatedMovie);
        Movie Get(int id);
        IEnumerable<Movie> GetAll();
        void Remove(int id);
    }
}