using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IUserTypeData
{
    Task DeleteUserType(int id);
    Task<UserTypeModel?> GetUserType(int id);
    Task<IEnumerable<UserTypeModel>> GetUserTypes();
    Task InsertUserType(UserTypeModel model);
    Task UpdateUserType(UserTypeModel model);
}