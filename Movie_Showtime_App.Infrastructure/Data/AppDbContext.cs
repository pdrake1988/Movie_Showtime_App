using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Showtime_App.Core.Models;

namespace Movie_Showtime_App.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = "1", Name = "Test User" }
            );
            modelBuilder.Entity<Tickets>().HasData(
                new Tickets { Id = 1, TheaterNumber = 3, SeatNumber = "E6", ShowTime = "5:30", MovieId = 1, UserId = 1 }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, MovieTitle = "Wonder Woman", Rating = "PG-13" }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = /C:/Users/Paul/source/repos/Movie_Showtime_App" +
                "/Movie_Showtime_App.Infrastructure/MovieApp.db");
        }
    }
}