using Api.Service;

namespace Api.Extension;

public static class JwtTokenGeneratorExtension
{
    public static IServiceCollection AddJwtTokenGenerator(
        this IServiceCollection services)
    {
        return services.AddScoped<JwtTokenGenerator>();
    }
}