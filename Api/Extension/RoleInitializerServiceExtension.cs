using Api.Common;
using Microsoft.AspNetCore.Identity;

namespace Api.Extension;

public static class RoleInitializerServiceExtension
{
    public static async Task InitializeRoleAsync(this IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var roleManager = scope
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in SharedData.Role.AllRoles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}