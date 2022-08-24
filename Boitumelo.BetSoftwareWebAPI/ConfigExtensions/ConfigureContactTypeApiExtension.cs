namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class ContactTypeApi
{
    public static void ConfigureContactTypeApi(this WebApplication app)
    {
        app.MapGet("/ContactType", GetContactTypes);
        app.MapGet("/ContactType/{id}", GetContactType);
        app.MapPost("/ContactType", InsertContactType);
        app.MapPut("/ContactType", UpdateContactType);
        app.MapDelete("/ContactType", DeleteContactType);
    }
    [Authorize]
    private static async Task<IResult> GetContactTypes(IContactTypeData data)
    {
        try
        {
            return Results.Ok(await data.GetContactTypes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetContactType(int id, IContactTypeData data)
    {
        try
        {
            var results = await data.GetContactType(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertContactType(ContactTypeModel model, IContactTypeData data)
    {
        try
        {
            await data.InsertContactType(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateContactType(ContactTypeModel model, IContactTypeData data)
    {
        try
        {
            await data.UpdateContactType(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteContactType(int id, IContactTypeData data)
    {
        try
        {
            await data.DeleteContactType(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
