using Api.Service;
using Api.Service.Payment;

namespace Api.Extension;

public static class BusinessLogicServiceExtension
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<CartService>();
        services.AddScoped<OrderService>();
        services.AddScoped<IPaymentService, FakePaymentService>();
        
        return services;
    }
}