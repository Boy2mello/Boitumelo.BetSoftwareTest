using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class UserSessionProfileData
{
    private readonly ISqlDataAccess _db;
    public UserSessionProfileData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task InsertUserSessionProfile(UserSessionProfileModel model)
    {

        string insertUserSql = @"INSERT INTO[dbo].[User]([Title],[FirstName],[LastName],[DateOfBirth])  OUTPUT INSERTED.[Id] " +
                                $"VALUES ({model.Title}, {model.Firstname}, {model.Lastname}, {model.DateOfBirth}) ";
        int userId = await _db.ExecuteCommand<int>(insertUserSql);
        await new ContactDetailData(_db).InsertContactDetail(new ContactDetailModel()
        {
            Contact = model.Email,
            UserID = userId,
            ContactTypeId = 1 //Ideally get a lookup link for contact type 
        });
        if (model.ShoppingCart is not null)
        {
            insertUserSql = @"INSERT INTO [dbo].[ShoppingCart] ([UserId],[IsOrdered],[OrderId])  OUTPUT INSERTED.[Id] " +
                                $"VALUES ({userId} , {model.ShoppingCart.IsOrdered}, {model.ShoppingCart.OrderId}) ";
            int shoppingCartId = await _db.ExecuteCommand<int>(insertUserSql);

            if (model.ShoppingCart.ShoppingCartItems is not null)
                for (int i = 0; i < model.ShoppingCart.ShoppingCartItems.Count; i++)
                {
                    ShoppingCartItemsModel? rec = model.ShoppingCart.ShoppingCartItems[i];
                    await new ShoppingCartItemData(_db).InsertShoppingCartItem(new ShoppingCartItemsModel()
                    {
                        ProductId = rec.ProductId,
                        ShoppingCartId = shoppingCartId
                    });
                }
        }
    }

    public async Task GetUserSessionProfileByEmail(string email)
    {
        var contactDet = await new ContactDetailData(_db).GetContactDetailsByEmail(email);

        UserModel? user = new UserModel();
        if (contactDet is not null)
            user = await new UserData(_db).GetUser(contactDet.UserID);

        ShoppingCartModel? cart = new ShoppingCartModel();
        if (user is not null)
        {
            cart = await new ShoppingCartData(_db).GetShoppingCartByUser(user.Id);


            ShoppingCartItemsModel? cartItens = new ShoppingCartItemsModel();
            if (cartItens is not null)
                cartItens = await new ShoppingCartItemData(_db).GetShoppingCartItemsByUser(user.Id);
        }
    }

    public async Task UpdateUserSessionProfile(UserSessionProfileModel model)
    {
        await new UserData(_db).UpdateUser(new UserModel()
        {
            Id = model.ProfileId,
            FirstName = model.Firstname,
            LastName = model.Lastname,  
            DateOfBirth = model.DateOfBirth
        });

        await new ContactDetailData(_db).UpdateContactDetail(new ContactDetailModel()
        {
            Id = model.ContactId,
            Contact = model.Email,
            UserID = model.ProfileId,
            ContactTypeId = 1 //Ideally get a lookup link for contact type 
        });

        if (model.ShoppingCart is not null)
        {
            await new ShoppingCartData(_db).UpdateShoppingCart(new ShoppingCartModel()
            {
                Id= model.ShoppingCart.Id,  
                IsOrdered = model.ShoppingCart.IsOrdered,
                OrderId = model.ShoppingCart.OrderId,
                ShoppingCartId = model.ShoppingCart.ShoppingCartId,
                UserId = model.ShoppingCart.UserId
            });

            if (model.ShoppingCart.ShoppingCartItems is not null)
                for (int i = 0; i < model.ShoppingCart.ShoppingCartItems.Count; i++)
                {
                    ShoppingCartItemsModel? rec = model.ShoppingCart.ShoppingCartItems[i];
                    await new ShoppingCartItemData(_db).UpdateShoppingCartItem(new ShoppingCartItemsModel()
                    {
                        Id = rec.Id,
                        ProductId = rec.ProductId,
                        ShoppingCartId = rec.ShoppingCartId
                    });
                }
        }
    }
}
