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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = /C:/Users/Paul/source/repos/Movie_Showtime_App" +
                "/Movie_Showtime_App.Infrastructure/MovieApp.db");
        }
    }
}