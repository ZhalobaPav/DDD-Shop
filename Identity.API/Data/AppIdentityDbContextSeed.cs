using Identity.API.Common;
using Identity.API.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Data
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext identityDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (identityDbContext.Database.IsSqlServer())
            {
                identityDbContext.Database.Migrate();
            }

            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATORS));

            var defaultUser = new AppUser { UserName = "demouser@microsoft.com", Email = "demouser@microsoft.com" };
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

            string adminUserName = "admin@microsoft.com";
            var adminUser = new AppUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS);
            }
        }
    }
}
