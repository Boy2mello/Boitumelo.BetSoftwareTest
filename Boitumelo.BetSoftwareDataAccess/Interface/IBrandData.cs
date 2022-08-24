using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IBrandData
{
    Task DeleteBrand(int id);
    Task<IEnumerable<BrandModel>> GetBrands();
    Task<BrandModel?> GetBrand(int id);
    Task InsertBrand(BrandModel model);
    Task UpdateBrand(BrandModel model);
}