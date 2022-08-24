using Boitumelo.BetSoftwareDataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Boitumelo.BetSoftwareWebAPI.Security;

public static class ConfigureApiSecurityExtension
{
    public static void ConfigureApiSecurity(this WebApplicationBuilder builder)
    {

        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security",
        };

        var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

        var contactInfo = new OpenApiContact()
        {
            Name = "Boitumelo Tsaagane",
            Email = "boy2mello@gmail.com",
            Url = new Uri("https://google.com")
        };

        var license = new OpenApiLicense()
        {
            Name = "Free License",
        };

        var info = new OpenApiInfo()
        {
            Version = "V1",
            Title = "BetSoftware Api with JWT Authentication",
            Description = "BetSoftware Api with JWT Authentication",
            Contact = contactInfo,
            License = license
        };

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", info);
            options.AddSecurityDefinition("Bearer", securityScheme);
            options.AddSecurityRequirement(securityReq);
        });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateLifetime = false, // In any other application other then demo this needs to be true,
                ValidateIssuerSigningKey = true
            };
        });

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
    }


}
