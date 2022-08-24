using Boitumelo.BetSoftwareWebAPI.Security;

namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class OrderDetailApi
{
 
    public static void ConfigureOrderDetailApi(this WebApplication app)
    {
        app.MapGet("/OrderDetail", GetOrderDetails);
        app.MapGet("/OrderDetail/{id}", GetOrderDetail);
        app.MapGet("/OrderDetail/Product/{id}", GetOrderDetailsByProduct);
        app.MapGet("/OrderDetail/order/{id}", GetOrderDetailsByOrder);
        app.MapPost("/OrderDetail", InsertOrderDetail);
        app.MapPut("/OrderDetail", UpdateOrderDetail);
        app.MapDelete("/OrderDetail", DeleteOrderDetail);
    }
    [Authorize]
    private static async Task<IResult> GetOrderDetails(IOrderDetailData data)
    {
        try
        {
            return Results.Ok(await data.GetOrderDetails());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetOrderDetail(int id, IOrderDetailData data)
    {
        try
        {
            var results = await data.GetOrderDetail(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetOrderDetailsByProduct(int id, IOrderDetailData data)
    {
        try
        {
            var results = await data.GetOrderDetailsByProduct(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]

    private static async Task<IResult> GetOrderDetailsByOrder(int id, IOrderDetailData data)
    {
        try
        {
            var results = await data.GetOrderDetailsByOrder(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertOrderDetail(OrderDetailModel model, IOrderDetailData data)
    {
        try
        {
            await data.InsertOrderDetail(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateOrderDetail(OrderDetailModel model, IOrderDetailData data)
    {
        try
        {
            await data.UpdateOrderDetail(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteOrderDetail(int id, IOrderDetailData data)
    {
        try
        {
            await data.DeleteOrderDetail(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
