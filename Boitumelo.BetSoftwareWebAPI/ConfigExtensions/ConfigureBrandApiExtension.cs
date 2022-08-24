

namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class BrandApi
{
    public static void ConfigureBrandApi(this WebApplication app)
    {
        app.MapGet("/Brand", GetBrands);
        app.MapGet("/Brand/{id}", GetBrand);
        app.MapPost("/Brand", InsertBrand);
        app.MapPut("/Brand", UpdateBrand);
        app.MapDelete("/Brand", DeleteBrand);
    }
    [Authorize]  
    private static async Task<IResult> GetBrands(IBrandData data)
    {
        try
        {
            return Results.Ok(await data.GetBrands());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetBrand(int id, IBrandData data)
    {
        try
        {
            var results = await data.GetBrand(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertBrand(BrandModel model, IBrandData data)
    {
        try
        {
            await data.InsertBrand(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateBrand(BrandModel model, IBrandData data)
    {
        try
        {
            await data.UpdateBrand(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteBrand(int id, IBrandData data)
    {
        try
        {
            await data.DeleteBrand(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
