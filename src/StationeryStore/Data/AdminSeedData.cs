using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;
namespace StationeryStore.Data;
public static class AdministratorSeedData
{
    public static async Task EnsureSeedDataAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        if (await _userManager.FindByNameAsync("superuser") == null)
        {
            
            var roleExist = await _roleManager.RoleExistsAsync("admin");
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }
            User administrator = new User()
            {
                UserName = "superuser"
            };
            await _userManager.CreateAsync(administrator, "S@per1");
            var result = await _userManager.AddToRoleAsync(administrator, "admin");
        }
    }
}