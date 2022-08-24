using System.Reflection;

namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class AddressApi
{
    public static void ConfigureAddressApi(this WebApplication app)
    {
        app.MapGet("/Address", GetAddresses);
        app.MapGet("/Address/{id}", GetAddress);
        app.MapGet("/Address/user/{id}", GetAddressByUser);
        app.MapPost("/Address", InsertAddress);
        app.MapPut("/Address", UpdateAddress);
        app.MapDelete("/Address", DeleteAddress);
    }
    [Authorize]
    private static async Task<IResult> GetAddresses(IAddressData data)
    {
        try
        {
            return Results.Ok(await data.GetAddresses());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize]
    private static async Task<IResult> GetAddressByUser(int id, IAddressData data)
    {
        try
        {
            var results = await data.GetAddressByUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetAddress(int id, IAddressData data)
    {
        try
        {
            var results = await data.GetAddress(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertAddress(AddressModel model, IAddressData data)
    {
        try
        {
            await data.InsertAddress(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateAddress(AddressModel model, IAddressData data)
    {
        try
        {
            await data.UpdateAddress(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteAddress(int id, IAddressData data)
    {
        try
        {
            await data.DeleteAddress(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}