using Microsoft.AspNetCore.Identity;
using Movie_Showtime_App.Core.Models;
using Movie_Showtime_App.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Showtime_App
{
    public class DbIntializer
    {
        private readonly UserManager<User> _userManager;
        private readonly ITicketRepository _ticketRepo;
        private readonly IMovieRepository _movieRepo;
        private RoleManager<IdentityRole> _roleManager;
        public DbIntializer(UserManager<User> userManager, ITicketRepository ticketRepo, IMovieRepository movieRepo, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _ticketRepo = ticketRepo;
            _movieRepo = movieRepo;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            AddAdminUser();
            AddTestUser();
            AddTestTicket();
        }
        public User CreateUser(string Email, string Name)
        {
            if (_userManager.FindByNameAsync(Email).Result == null)
            {
                User user = new User
                {
                    UserName = Email,
                    Name = Name,
                    Email = Email,

                };
                // add user
                var result = _userManager.CreateAsync(user, "Testing123!").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }
        public void AddTestUser()
        {
            var testUsers = new[]
            {
                new
                {
                    Email = "john.smith@test.com",
                    Name = "John Smith"
                },
                new
                {
                    Email = "jane.doe@test.com",
                    Name = "Jane Doe"
                }
            };

            foreach (var user in testUsers)
            {
                CreateUser(user.Email, user.Name);
            }
        }
        public void AddTestTicket()
        {
            if ( _ticketRepo.GetAll().Count() > 0) return;
            var john = _userManager.FindByNameAsync("john.smith@test.com").Result;
            var jane = _userManager.FindByNameAsync("jane.doe@test.com").Result;
            var johnTicket1 = CreateTestTicket(1, 3, "A4", "3:30", 1, 1, john);
            _ticketRepo.Add(johnTicket1);
        }
        private Tickets CreateTestTicket(int ticketId, int theaterNumber, string seatNumber, string showTime, int movieId, int userId, User user)
        {
            return new Tickets
            {

                Id = ticketId,
                TheaterNumber = theaterNumber,
                SeatNumber = seatNumber,
                ShowTime = showTime,
                UserId = userId,
                Movie = new Movie
                {
                    Id = 1,
                    MovieTitle = "Test",
                    Rating = "R"
                }

            };
        }
        private void AddAdminUser()
        {
            // create an Admin role, if it doesn't already exist
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}