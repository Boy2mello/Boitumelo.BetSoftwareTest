using Boitumelo.BetSoftwareDataAccess.DataAccess;

namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class DataConfigExtensions
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

        builder.Services.AddSingleton<IAddressData, AddressData>();
        builder.Services.AddSingleton<IBrandData, BrandData>();
        builder.Services.AddSingleton<IContactDetailData, ContactDetailData>();
        builder.Services.AddSingleton<IContactTypeData, ContactTypeData>();
        builder.Services.AddSingleton<IOrderData, OrderData>();
        builder.Services.AddSingleton<IOrderDetailData, OrderDetailData>();
        builder.Services.AddSingleton<IPaymentData, PaymentData>();
        builder.Services.AddSingleton<IProductData, ProductData>();
        builder.Services.AddSingleton<IShippingMethodData, ShippingMethodData>();
        builder.Services.AddSingleton<IUserData, UserData>();
        builder.Services.AddSingleton<IUserTypeData, UserTypeData>();

       
    }
}
