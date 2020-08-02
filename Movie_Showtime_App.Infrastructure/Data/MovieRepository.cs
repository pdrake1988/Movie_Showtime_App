﻿using System;
using System.Collections.Generic;
using System.Text;
using Movie_Showtime_App.Core.Models;
using Movie_Showtime_App.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Movie_Showtime_App.Infrastructure.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _dbContext;
        public MovieRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Movie Add(Movie newMovie)
        {
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();
            return newMovie;
        }

        public Movie Get(int id)
        {
            return _dbContext.Movies
                    .FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies
                    .ToList();
        }

        public void Remove(int id)
        {
            var deleteMovie = _dbContext.Movies.Find(id);
            if(deleteMovie != null)
            {
                _dbContext.Movies.Remove(deleteMovie);
                _dbContext.SaveChanges();
            }
        }

        public Movie Update(Movie updatedMovie)
        {
            var selectedMovie = _dbContext.Movies.Find(updatedMovie.Id);
            if (selectedMovie == null) return null;
            _dbContext.Entry(selectedMovie)
                .CurrentValues
                .SetValues(updatedMovie);
            return selectedMovie;
        }
    }
}
