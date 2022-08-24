namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class OrderApi
{
    public static void ConfigureOrderApi(this WebApplication app)
    {
        app.MapGet("/Order", GetOrders);
        app.MapGet("/Order/{id}", GetOrder);
        app.MapGet("/Order/customer/{id}", GetOrdersByCustomer);
        app.MapGet("/Order/salesperson/{id}", GetOrdersBySalesPerson);
        app.MapGet("/Order/shippingmethod/{id}", GetOrdersByShippingMethod);
        app.MapPost("/Order", InsertOrder);
        app.MapPut("/Order", UpdateOrder);
        app.MapDelete("/Order", DeleteOrder);
    }
    [Authorize]
    private static async Task<IResult> GetOrders(IOrderData data)
    {
        try
        {
            return Results.Ok(await data.GetOrders());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetOrdersByCustomer(int id, IOrderData data)
    {
        try
        {
            var results = await data.GetOrdersByCustomer(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetOrdersBySalesPerson(int id, IOrderData data)
    {
        try
        {
            var results = await data.GetOrdersBySalesPerson(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetOrdersByShippingMethod(int id, IOrderData data)
    {
        try
        {
            var results = await data.GetOrdersByShippingMethod(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetOrder(int id, IOrderData data)
    {
        try
        {
            var results = await data.GetOrder(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertOrder(OrderModel model, IOrderData data)
    {
        try
        {
            await data.InsertOrder(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateOrder(OrderModel model, IOrderData data)
    {
        try
        {
            await data.UpdateOrder(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteOrder(int id, IOrderData data)
    {
        try
        {
            await data.DeleteOrder(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
