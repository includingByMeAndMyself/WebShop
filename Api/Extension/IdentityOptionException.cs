using Microsoft.AspNetCore.Identity;

namespace Api.Extension;

public static class IdentityOptionException
{
    public static IServiceCollection AddConfigureIdentityOption(this IServiceCollection service)
    {
        return service.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 10;
            }
        );
    }
}