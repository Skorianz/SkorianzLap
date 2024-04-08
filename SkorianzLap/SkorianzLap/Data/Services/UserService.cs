using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SkorianzLap.Data.Models;

namespace SkorianzLap.Data.Services
{
    public class UserService
    {
        private IServiceProvider _serviceProvider;

        public UserService (IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public async Task CreateDefaultRoles()
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public async Task AddUserToRole(string userEmail, string roleName)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync(userEmail);

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);

                if(roles != null && !roles.Contains(roleName))
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
                
            }
        }

        public async Task RemoveUserToRole(string userEmail, string roleName)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync(userEmail);

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);

                if (roles != null && roles.Contains(roleName))
                {
                    await userManager.RemoveFromRoleAsync(user, roleName);
                }

            }
        }
    }
}
