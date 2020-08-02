using Movie_Showtime_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Showtime_App.API_Models
{
    public static class UserMappingExtensions
    {
        public static UserModel ToApiModel(this User domainItem)
        {
            return new UserModel
            {
                Id = domainItem.Id,
                Name = domainItem.Name,
                Email = domainItem.Email
            };
        }
        public static User ToDomainModel(this UserModel apiModel)
        {
            return new User
            {
                Id = apiModel.Id,
                Name = apiModel.Name,
                Email = apiModel.Email
            };
        }
        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> domainObjects)
        {
            return domainObjects.Select(u => u.ToApiModel());
        }
        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> userModels)
        {
            return userModels.Select(u => u.ToDomainModel());
        }
    }
}
