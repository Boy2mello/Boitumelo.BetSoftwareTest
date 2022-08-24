using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class UserTypeData : IUserTypeData
{
    private readonly ISqlDataAccess _db;
    public UserTypeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserTypeModel>> GetUserTypes() =>
        _db.LoadData<UserTypeModel, dynamic>("[dbo].[sp_GetUserTypes]", new { });

    public async Task<UserTypeModel?> GetUserType(int id) =>
     (await _db.LoadData<UserTypeModel, dynamic>
                    ("[dbo].[sp_GetUserTypesById]", new { id })).FirstOrDefault();


    public Task InsertUserType(UserTypeModel model) =>
        _db.SaveData("[dbo].[sp_InsertUserTypes]", new
        {
            model.UserType
        });

    public Task UpdateUserType(UserTypeModel model) =>
    _db.SaveData("[dbo].[sp_UpdateUserTypes]", new { model });

    public Task DeleteUserType(int id) =>
        _db.SaveData("[dbo].[sp_DeleteUserTypes]", new { id });
}
