using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProjektBackend.Core.Entities;
using ProjektBackend.Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProjektBackend.Infrastructure;

namespace ProjektBackend.Infrastructure
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var context = serviceProvider.GetRequiredService<ApplicationDBContext>();

            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
            SeedData(context);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Administrator", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var adminUser = await userManager.FindByEmailAsync("admin@admin.pl");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin@admin.pl",
                    Email = "admin@admin.pl",
                    FirstName = "Admin",
                    LastName = "User"
                };
                await userManager.CreateAsync(adminUser, "Admin123@");
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }
        }

        private static void SeedData(ApplicationDBContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Categories { CategoryName = "SUV" },
                    new Categories { CategoryName = "Sedan" }
                );
                context.SaveChanges();
            }

            if (!context.Cars.Any())
            {
                var suvCategory = context.Categories.First(c => c.CategoryName == "SUV");
                var sedanCategory = context.Categories.First(c => c.CategoryName == "Sedan");

                context.Cars.AddRange(
                    new Cars { Brand = "Toyota", Model = "RAV4", CategoryId = suvCategory.CategoryId, CategoryName = suvCategory.CategoryName },
                    new Cars { Brand = "Honda", Model = "Civic", CategoryId = sedanCategory.CategoryId, CategoryName = suvCategory.CategoryName }
                );
                context.SaveChanges();
            }

            if (!context.Clients.Any())
            {
                context.Clients.Add(new Clients
                {
                    FirstName = "Jan",
                    LastName = "Kowal",
                    Email = "jankowal@gmail.com",
                });
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var client = context.Clients.First();
                var car = context.Cars.First();

                context.Orders.Add(new Orders
                {
                    OrderDate = DateTime.Now,
                    UserId = null,
                    ClientId = client.ClientId,
                    CarId = car.CarId,
                    PickupDate = DateTime.Now.AddDays(1),
                    ReturnDate = DateTime.Now.AddDays(7),
                });
                context.SaveChanges();
            }
        }
    }
}
