using Boitumelo.BetSoftwareWeb.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareWeb.Repository
{
    public interface IUserRepository
    {
        Task<Tuple<UserSessionProfileModel>> GetCurrentUserProfile(ClaimsIdentity claims);
        Task<Tuple<UserModel>> GetUser(int userId);
        Task<Tuple<bool>> InitUserProfile(ClaimsIdentity claims);
        Task<Tuple<UserModel>> InsertUser(UserModel userModel);
        Task<Tuple<UserModel>> UpdateUser(UserModel user);
    }
}