namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class UserTypesApi
{
    public static void ConfigureUserTypeApi(this WebApplication app)
    {
        app.MapGet("/UserType", GetUserTypes);
        app.MapGet("/UserType/{id}", GetUserType);
        app.MapPost("/UserType", InsertUserType);
        app.MapPut("/UserType", UpdateUserType);
        app.MapDelete("/UserType", DeleteUserType);
    }
    [Authorize]
    private static async Task<IResult> GetUserTypes(IUserTypeData data)
    {
        try
        {
            return Results.Ok(await data.GetUserTypes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetUserType(int id, IUserTypeData data)
    {
        try
        {
            var results = await data.GetUserType(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertUserType(UserTypeModel model, IUserTypeData data)
    {
        try
        {
            await data.InsertUserType(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateUserType(UserTypeModel model, IUserTypeData data)
    {
        try
        {
            await data.UpdateUserType(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteUserType(int id, IUserTypeData data)
    {
        try
        {
            await data.DeleteUserType(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
