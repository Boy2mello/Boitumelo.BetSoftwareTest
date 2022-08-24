using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class ProductData : IProductData
{
    private readonly ISqlDataAccess _db;
    public ProductData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ProductModel>> GetProducts() =>
        _db.LoadData<ProductModel, dynamic>("[dbo].[sp_GetProducts]", new { });

    public async Task<ProductModel?> GetProduct(int id) =>
     (await _db.LoadData<ProductModel, dynamic>
                    ("[dbo].[sp_GetProductsById]", new { id })).FirstOrDefault();

    public async Task<ProductModel?> GetProductsByBrand(int id) =>
     (await _db.LoadData<ProductModel, dynamic>
                    ("[dbo].[sp_GetProductsBrandId]", new { id })).FirstOrDefault();

    public Task InsertProduct(ProductModel model) =>
        _db.SaveData("[dbo].[sp_InsertProducts]", new
        {
            model.BrandId,
            model.ProductName
        });

    public Task UpdateProduct(ProductModel model) =>
    _db.SaveData("[dbo].[sp_UpdateProducts]", new { model });

    public Task DeleteProduct(int id) =>
        _db.SaveData("[dbo].[sp_DeleteProducts]", new { id });
}
