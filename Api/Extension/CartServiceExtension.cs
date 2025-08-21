using Api.Service;

namespace Api.Extension;

public static class CartServiceExtension
{
    public static IServiceCollection AddCartService(
        this IServiceCollection services)
    {
        return services.AddScoped<CartService>();
    }
}