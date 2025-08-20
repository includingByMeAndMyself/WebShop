using Api.Data;
using Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extension;

public static class PostgresSqlServiceExtension
{
    public static void AddPostgresSqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgresSQLConnection"));
        });
    }

    public static void AddPostgresSqlIdentityContext(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
}