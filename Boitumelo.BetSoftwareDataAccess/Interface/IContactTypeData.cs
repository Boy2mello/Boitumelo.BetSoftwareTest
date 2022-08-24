using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IContactTypeData
{
    Task DeleteContactType(int id);
    Task<IEnumerable<ContactTypeModel>> GetContactTypes();
    Task<ContactTypeModel?> GetContactType(int id);
    Task InsertContactType(ContactTypeModel model);
    Task UpdateContactType(ContactTypeModel model);
}