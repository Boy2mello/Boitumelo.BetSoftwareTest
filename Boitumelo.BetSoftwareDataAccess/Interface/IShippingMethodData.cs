using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IShippingMethodData
{
    Task DeleteShippingMethod(int id);
    Task<ShippingMethodModel?> GetShippingMethod(int id);
    Task<IEnumerable<ShippingMethodModel>> GetShippingMethods();
    Task InsertShippingMethod(ShippingMethodModel model);
    Task UpdateShippingMethod(ShippingMethodModel model);
}