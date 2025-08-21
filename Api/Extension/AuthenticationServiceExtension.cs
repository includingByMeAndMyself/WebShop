using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.Extension;

public static class AuthenticationServiceExtension
{
    public static IServiceCollection AddAuthenticationService(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        var token = configuration["AuthSettings:SecretKey"];

        service.AddAuthentication(u =>
        {
            u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(u =>
        {
            u.RequireHttpsMetadata = false;
            u.SaveToken = true;
            u.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        
        return service;
    }
}