namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class PaymentApi
{
    public static void ConfigurePaymentApi(this WebApplication app)
    {
        app.MapGet("/Payment", GetPayments);
        app.MapGet("/Payment/{id}", GetPayment);
        app.MapGet("/Payment/payment/{id}", GetPaymentsByPayment);
        app.MapGet("/Payment/order/{id}", GetPaymentsByOrder);
        app.MapPost("/Payment", InsertPayment);
        app.MapPut("/Payment", UpdatePayment);
        app.MapDelete("/Payment", DeletePayment);
    }
    [Authorize]
    private static async Task<IResult> GetPayments(IPaymentData data)
    {
        try
        {
            return Results.Ok(await data.GetPayments());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetPayment(int id, IPaymentData data)
    {
        try
        {
            var results = await data.GetPayment(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetPaymentsByPayment(int id, IPaymentData data)
    {
        try
        {
            var results = await data.GetPaymentsByPayment(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetPaymentsByOrder(int id, IPaymentData data)
    {
        try
        {
            var results = await data.GetPaymentsByOrder(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertPayment(PaymentModel model, IPaymentData data)
    {
        try
        {
            await data.InsertPayment(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdatePayment(PaymentModel model, IPaymentData data)
    {
        try
        {
            await data.UpdatePayment(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeletePayment(int id, IPaymentData data)
    {
        try
        {
            await data.DeletePayment(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}