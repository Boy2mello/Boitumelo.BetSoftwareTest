using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class UserData : IUserData
{
	private readonly ISqlDataAccess _db;
	public UserData(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<UserModel>> GetUsers() =>
		_db.LoadData<UserModel, dynamic>("[dbo].[sp_GetUsers]", new { });

	public async Task<UserModel?> GetUser(int id) =>
	 (await _db.LoadData<UserModel, dynamic>
					("[dbo].[sp_GetUsersById]", new { id })).FirstOrDefault();


	public Task InsertUser(UserModel model) =>
		_db.SaveData("[dbo].[sp_InsertUsers]", new { model.FirstName, model.LastName, model.DateOfBirth });

	public Task UpdateUser(UserModel model) =>
	_db.SaveData("[dbo].[sp_UpdateUsers]", new { model });

	public Task DeleteUser(int id) =>
		_db.SaveData("[dbo].[sp_DeleteUsers]", new { id });

}
