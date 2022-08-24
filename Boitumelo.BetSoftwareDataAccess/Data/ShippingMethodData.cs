using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class ShippingMethodData : IShippingMethodData
{
    private readonly ISqlDataAccess _db;
    public ShippingMethodData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ShippingMethodModel>> GetShippingMethods() =>
        _db.LoadData<ShippingMethodModel, dynamic>("[dbo].[sp_GetShippingMethods]", new { });

    public async Task<ShippingMethodModel?> GetShippingMethod(int id) =>
     (await _db.LoadData<ShippingMethodModel, dynamic>
                    ("[dbo].[sp_GetShippingMethodsById]", new { id })).FirstOrDefault();


    public Task InsertShippingMethod(ShippingMethodModel model) =>
        _db.SaveData("[dbo].[sp_InsertShippingMethods]", new
        {
            model.ShippingMethod
        });

    public Task UpdateShippingMethod(ShippingMethodModel model) =>
    _db.SaveData("[dbo].[sp_UpdateShippingMethods]", new { model });

    public Task DeleteShippingMethod(int id) =>
        _db.SaveData("[dbo].[sp_DeleteShippingMethods]", new { id });
}
