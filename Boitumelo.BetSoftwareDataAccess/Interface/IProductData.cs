using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IProductData
{
    Task DeleteProduct(int id);
    Task<ProductModel?> GetProduct(int id);
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<ProductModel?> GetProductsByBrand(int id);
    Task InsertProduct(ProductModel model);
    Task UpdateProduct(ProductModel model);
}