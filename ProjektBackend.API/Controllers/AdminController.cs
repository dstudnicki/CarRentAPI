using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektBackend.Shared.Models;

namespace ProjektBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("CreateAdminUser")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateAdminUser()
        {
            string roleName = "Administrator";
            IdentityResult roleResult;

            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist)
            {
                roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = await _userManager.FindByEmailAsync("admin@admin.pl");

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "admin@admin.pl",
                    Email = "admin@admin.pl",
                };
                await _userManager.CreateAsync(user, "Admin123@");
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }

            return Ok();
        }
    }
}
