using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektBackend.Shared.Models;

namespace ProjektBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdminUser()
        {
            string roleName = "Administrator";
            IdentityResult roleResult;

            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist)
            {
                roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded)
                {
                    return BadRequest(roleResult.Errors);
                }
            }

            var user = await _userManager.FindByEmailAsync("admin@admin.pl");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin@admin.pl",
                    Email = "admin@admin.pl",
                    FirstName = "Admin",
                    LastName = "User"
                };
                var createUserResult = await _userManager.CreateAsync(user, "Admin123@");

                if (!createUserResult.Succeeded)
                {
                    return BadRequest(createUserResult.Errors);
                }
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                var addToRoleResult = await _userManager.AddToRoleAsync(user, roleName);
                if (!addToRoleResult.Succeeded)
                {
                    return BadRequest(addToRoleResult.Errors);
                }
            }

            return Ok();
        }
    }
}
