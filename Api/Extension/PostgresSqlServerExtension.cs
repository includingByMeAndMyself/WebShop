using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extension;

public static class PostgresSqlServerExtension
{
    public static void AddPostgresSqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgresSQLConnection"));
        });

    }
}