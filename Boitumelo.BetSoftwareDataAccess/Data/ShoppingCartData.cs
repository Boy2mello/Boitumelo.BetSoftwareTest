using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class ShoppingCartData
{
    private readonly ISqlDataAccess _db;
    public ShoppingCartData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ShoppingCartModel>> GetShoppingCarts() =>
        _db.LoadData<ShoppingCartModel, dynamic>("[dbo].[sp_GetShoppingCarts]", new { });

    public async Task<ShoppingCartModel?> GetShoppingCart(int id) =>
     (await _db.LoadData<ShoppingCartModel, dynamic>
                    ("[dbo].[sp_GetShoppingCartById]", new { id })).FirstOrDefault();

    public async Task<ShoppingCartModel?> GetShoppingCartByUser(int id) =>
     (await _db.LoadData<ShoppingCartModel, dynamic>
                    ("[dbo].[sp_GetShoppingCartByUserId]", new { id })).FirstOrDefault();

    public async Task<ShoppingCartModel?> GetShoppingCartByOrder(int id) =>
 (await _db.LoadData<ShoppingCartModel, dynamic>
                ("[dbo].[sp_GetShoppingCartByOrderId]", new { id })).FirstOrDefault();

    public Task InsertShoppingCart(ShoppingCartModel model) =>
        _db.SaveData("[dbo].[sp_InsertShoppingCart]", new
        {
            model.UserId,
            model.IsOrdered,
            model.OrderId
        });

    public Task UpdateShoppingCart(ShoppingCartModel model) =>
    _db.SaveData("[dbo].[sp_UpdateShoppingCart]", new { model });

    public Task DeleteShoppingCart(int id) =>
        _db.SaveData("[dbo].[sp_DeleteShoppingCart]", new { id });
}





















