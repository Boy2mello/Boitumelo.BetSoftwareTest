using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IContactDetailData
{
    Task DeleteContactDetail(int id);
    Task<ContactDetailModel?> GetContactDetail(int id);
    Task<IEnumerable<ContactDetailModel>> GetContactDetails();
    Task<ContactDetailModel?> GetContactDetailsByUser(int id);
    Task<ContactDetailModel?> GetContactDetailsByEmail(string email);
    Task InsertContactDetail(ContactDetailModel model);
    Task UpdateContactDetail(ContactDetailModel model);
}