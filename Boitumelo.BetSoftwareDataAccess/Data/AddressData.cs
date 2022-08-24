using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class AddressData : IAddressData
{
    private readonly ISqlDataAccess _db;
    public AddressData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<AddressModel>> GetAddresses() =>
        _db.LoadData<AddressModel, dynamic>("[dbo].[sp_GetAddress]", new { });

    public async Task<AddressModel?> GetAddress(int id) =>
     (await _db.LoadData<AddressModel, dynamic>
                    ("[dbo].[sp_GetAddressById]", new { id })).FirstOrDefault();

    public async Task<AddressModel?> GetAddressByUser(int id) =>
     (await _db.LoadData<AddressModel, dynamic>
                    ("[dbo].[sp_GetAddressByUserId]", new { id })).FirstOrDefault();

    public Task InsertAddress(AddressModel model) =>
        _db.SaveData("[dbo].[sp_InsertAddress]", new
        {
            model.UserId,
            model.Address1,
            model.Address2,
            model.Address3,
            model.Country,
            model.City,
            model.Town,
            model.AreaCode
        });

    public Task UpdateAddress(AddressModel model) =>
    _db.SaveData("[dbo].[sp_UpdateAddress]", new { model });

    public Task DeleteAddress(int id) =>
        _db.SaveData("[dbo].[sp_DeleteAddress]", new { id });
}
