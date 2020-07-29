using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Showtime_App.Core.Services
{
    interface IUserRepository
    {
        User Add(User newUser);
        User Update(User updatedUser);
        User Get(int id);
        IEnumerable<User> GetAll();
        void Remove(int id);
    }
}
