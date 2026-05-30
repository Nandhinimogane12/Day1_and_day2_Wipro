using Microsoft.AspNetCore.Identity;
using SecureTaskManager.Models;

namespace SecureTaskManager.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var roleManager =
                service.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager =
                service.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            var adminEmail = "admin@test.com";

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                await userManager.CreateAsync(user, "Admin@123");

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}