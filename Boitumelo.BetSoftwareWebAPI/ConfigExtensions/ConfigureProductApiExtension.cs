namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class ProductApi
{
    public static void ConfigureProductApi(this WebApplication app)
    {
        app.MapGet("/Product", GetProducts);
        app.MapGet("/Product/{id}", GetProduct);        
        app.MapGet("/Product/brand/{id}", GetProductsByBrand);
        app.MapPost("/Product", InsertProduct);
        app.MapPut("/Product", UpdateProduct);
        app.MapDelete("/Product", DeleteProduct);
    }
    [Authorize]
    private static async Task<IResult> GetProducts(IProductData data)
    {
        try
        {
            return Results.Ok(await data.GetProducts());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetProduct(int id, IProductData data)
    {
        try
        {
            var results = await data.GetProduct(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetProductsByBrand(int id, IProductData data)
    {
        try
        {
            var results = await data.GetProductsByBrand(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertProduct(ProductModel model, IProductData data)
    {
        try
        {
            await data.InsertProduct(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateProduct(ProductModel model, IProductData data)
    {
        try
        {
            await data.UpdateProduct(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteProduct(int id, IProductData data)
    {
        try
        {
            await data.DeleteProduct(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
