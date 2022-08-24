namespace Boitumelo.BetSoftwareWebAPI.ConfigExtensions;

public static class ContactDetailApi
{
    public static void ConfigureContactDetailApi(this WebApplication app)
    {
        app.MapGet("api/ContactDetail", GetContactDetails);
        app.MapGet("api/ContactDetail/{id}", GetContactDetail);
        app.MapGet("api/ContactDetail/user/{id}", GetContactDetailByUser);
        app.MapGet("api/ContactDetail/email/{contact}", GetContactDetailByEmail);
        app.MapPost("api/ContactDetail", InsertContactDetail);
        app.MapPut("api/ContactDetail", UpdateContactDetail);
        app.MapDelete("api/ContactDetail", DeleteContactDetail);
    }
    [Authorize]
    private static async Task<IResult> GetContactDetails(IContactDetailData data)
    {
        try
        {
            return Results.Ok(await data.GetContactDetails());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize]
    private static async Task<IResult> GetContactDetailByUser(int id, IContactDetailData data)
    {
        try
        {
            var results = await data.GetContactDetailsByUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> GetContactDetailByEmail(string email, IContactDetailData data)
    {
        try
        {
            var results = await data.GetContactDetailsByEmail(email);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize]
    private static async Task<IResult> GetContactDetail(int id, IContactDetailData data)
    {
        try
        {
            var results = await data.GetContactDetail(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> InsertContactDetail(ContactDetailModel model, IContactDetailData data)
    {
        try
        {
            await data.InsertContactDetail(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> UpdateContactDetail(ContactDetailModel model, IContactDetailData data)
    {
        try
        {
            await data.UpdateContactDetail(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize]
    private static async Task<IResult> DeleteContactDetail(int id, IContactDetailData data)
    {
        try
        {
            await data.DeleteContactDetail(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
