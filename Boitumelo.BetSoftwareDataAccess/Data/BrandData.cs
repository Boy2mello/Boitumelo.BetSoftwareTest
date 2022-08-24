using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class BrandData : IBrandData
{
    private readonly ISqlDataAccess _db;
    public BrandData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<BrandModel>> GetBrands() =>
        _db.LoadData<BrandModel, dynamic>("[dbo].[sp_GetBrands]", new { });

    public async Task<BrandModel?> GetBrand(int id) =>
     (await _db.LoadData<BrandModel, dynamic>
                    ("[dbo].[sp_GetBrandsById]", new { id })).FirstOrDefault();

    public Task InsertBrand(BrandModel model) =>
        _db.SaveData("[dbo].[sp_InsertBrands]", new
        {
            model.BrandDescription
        });

    public Task UpdateBrand(BrandModel model) =>
    _db.SaveData("[dbo].[sp_UpdateBrands]", new { model });

    public Task DeleteBrand(int id) =>
        _db.SaveData("[dbo].[sp_DeleteBrands]", new { id });
}
