using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class ShoppingCartItemData
{
    private readonly ISqlDataAccess _db;
    public ShoppingCartItemData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ShoppingCartItemsModel>> GetShoppingCartItems() =>
        _db.LoadData<ShoppingCartItemsModel, dynamic>("[dbo].[sp_GetShoppingCartItems]", new { });

    public async Task<ShoppingCartItemsModel?> GetShoppingCartItem(int id) =>
     (await _db.LoadData<ShoppingCartItemsModel, dynamic>
                    ("[dbo].[sp_GetShoppingCartItemById]", new { id })).FirstOrDefault();

    public async Task<ShoppingCartItemsModel?> GetShoppingCartItemsByUser(int id) =>
     (await _db.LoadData<ShoppingCartItemsModel, dynamic>
                    ("[dbo].[sp_GetShoppingCartItemsByUserId]", new { id })).FirstOrDefault();


    public Task InsertShoppingCartItem(ShoppingCartItemsModel model) =>
        _db.SaveData("[dbo].[sp_InsertShoppingCartItem]", new
        {
            model.ProductId,
            model.ShoppingCartId
        });

    public Task UpdateShoppingCartItem(ShoppingCartItemsModel model) =>
    _db.SaveData("[dbo].[sp_UpdateShoppingCartItem]", new { model });

    public Task DeleteShoppingCartItem(int id) =>
        _db.SaveData("[dbo].[sp_DeleteShoppingCartItem]", new { id });
}
