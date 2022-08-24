using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareWebAPI.ConfigExtensions;
using Boitumelo.BetSoftwareWebAPI.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureDataAccess();
builder.ConfigureApiSecurity();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureAddressApi();
app.ConfigureBrandApi();
app.ConfigureContactDetailApi();
app.ConfigureContactTypeApi();
app.ConfigureOrderApi();
app.ConfigureOrderDetailApi();
app.ConfigurePaymentApi();
app.ConfigureProductApi();
app.ConfigureShippingMethodApi();
app.ConfigureUserApi();
app.ConfigureUserTypeApi();

app.MapPost("/security/login", [AllowAnonymous] (TokenCredentialsModel user) =>
{
    if (user.Username == "boy2mello@gmail.com" && user.Password == "Password123")// Ideally this needs to come from the Db, time is not on my side.
    {
        var secureKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey(secureKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("Id", "1"),
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.Now.AddMinutes(5),
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = credentials
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return Results.Ok(jwtToken);
    }
    return Results.Unauthorized();
});

app.UseAuthentication();
app.UseAuthorization();

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}