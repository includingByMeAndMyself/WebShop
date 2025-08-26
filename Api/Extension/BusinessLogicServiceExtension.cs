using Api.Service;

namespace Api.Extension;

public static class BusinessLogicServiceExtension
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<CartService>();
        services.AddScoped<OrderService>();
        
        return services;
    }
}