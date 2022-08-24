using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class ContactDetailData : IContactDetailData
{
    private readonly ISqlDataAccess _db;
    public ContactDetailData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ContactDetailModel>> GetContactDetails() =>
        _db.LoadData<ContactDetailModel, dynamic>("[dbo].[sp_GetContactDetails]", new { });

    public async Task<ContactDetailModel?> GetContactDetail(int id) =>
     (await _db.LoadData<ContactDetailModel, dynamic>
                    ("[dbo].[sp_GetContactDetailsById]", new { id })).FirstOrDefault();

    public async Task<ContactDetailModel?> GetContactDetailsByUser(int id) =>
     (await _db.LoadData<ContactDetailModel, dynamic>
                    ("[dbo].[sp_GetContactDetailsByUserId]", new { id })).FirstOrDefault();

    public async Task<ContactDetailModel?> GetContactDetailsByEmail(string email) =>
     (await _db.LoadData<ContactDetailModel, dynamic>
                    ("[dbo].[sp_GetContactDetailsByContact]", new { email })).FirstOrDefault();

    public Task InsertContactDetail(ContactDetailModel model) =>
        _db.SaveData("[dbo].[sp_InsertContactDetails]", new
        {
            model.UserID,
            model.ContactTypeId,
            model.Contact
        });

    public Task UpdateContactDetail(ContactDetailModel model) =>
    _db.SaveData("[dbo].[sp_UpdateContactDetails]", new { model });

    public Task DeleteContactDetail(int id) =>
        _db.SaveData("[dbo].[sp_DeleteContactDetails]", new { id });
}
