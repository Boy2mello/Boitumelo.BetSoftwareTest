using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IAddressData
{
    Task DeleteAddress(int id);
    Task<IEnumerable<AddressModel>> GetAddresses();
    Task<AddressModel?> GetAddressByUser(int id);
    Task<AddressModel?> GetAddress(int id);
    Task InsertAddress(AddressModel model);
    Task UpdateAddress(AddressModel model);
}