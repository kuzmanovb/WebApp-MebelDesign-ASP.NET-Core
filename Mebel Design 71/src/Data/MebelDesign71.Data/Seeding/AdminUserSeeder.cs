namespace MebelDesign71.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Common;
    using MebelDesign71.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, GlobalConstants.AdministratorEmail);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string userName)
        {
            var userAdmin = await userManager.FindByNameAsync(userName);

            if (userAdmin == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };

                var result = await userManager.CreateAsync(newUser, "12345678");

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }

                await userManager.AddToRoleAsync(newUser, GlobalConstants.AdministratorRoleName);
            }
        }

    }
}
