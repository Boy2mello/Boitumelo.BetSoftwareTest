namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class ShippingMethodApi
{
    [Authorize]
    public static void ConfigureShippingMethodApi(this WebApplication app)
    {
        app.MapGet("/ShippingMethod", GetShippingMethods);
        app.MapGet("/ShippingMethod/{id}", GetShippingMethod);
        app.MapPost("/ShippingMethod", InsertShippingMethod);
        app.MapPut("/ShippingMethod", UpdateShippingMethod);
        app.MapDelete("/ShippingMethod", DeleteShippingMethod);
    }
    [Authorize]
    private static async Task<IResult> GetShippingMethods(IShippingMethodData data)
    {
        try
        {
            return Results.Ok(await data.GetShippingMethods());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetShippingMethod(int id, IShippingMethodData data)
    {
        try
        {
            var results = await data.GetShippingMethod(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize]
    private static async Task<IResult> InsertShippingMethod(ShippingMethodModel model, IShippingMethodData data)
    {
        try
        {
            await data.InsertShippingMethod(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateShippingMethod(ShippingMethodModel model, IShippingMethodData data)
    {
        try
        {
            await data.UpdateShippingMethod(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteShippingMethod(int id, IShippingMethodData data)
    {
        try
        {
            await data.DeleteShippingMethod(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
