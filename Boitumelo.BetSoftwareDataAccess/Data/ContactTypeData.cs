using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class ContactTypeData : IContactTypeData
{
    private readonly ISqlDataAccess _db;
    public ContactTypeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ContactTypeModel>> GetContactTypes() =>
        _db.LoadData<ContactTypeModel, dynamic>("[dbo].[sp_GetContactTypes]", new { });

    public async Task<ContactTypeModel?> GetContactType(int id) =>
     (await _db.LoadData<ContactTypeModel, dynamic>
                    ("[dbo].[sp_GetContactTypesById]", new { id })).FirstOrDefault();


    public Task InsertContactType(ContactTypeModel model) =>
        _db.SaveData("[dbo].[sp_InsertContactTypes]", new
        {
            model.ContactType
        });

    public Task UpdateContactType(ContactTypeModel model) =>
    _db.SaveData("[dbo].[sp_UpdateContactTypes]", new { model });

    public Task DeleteContactType(int id) =>
        _db.SaveData("[dbo].[sp_DeleteContactTypes]", new { id });
}
