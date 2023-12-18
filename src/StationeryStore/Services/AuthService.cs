using Microsoft.AspNetCore.Identity;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;
namespace StationeryStore.Services;
public class AuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AuthService(ILogger<AuthService> logger, 
        UserManager<User> userManager, 
        SignInManager<User> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<IList<string>?> LoginUser(AuthViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if(user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))
        {
            return null;
        }
        await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        return userRoles;
    }

    public async Task<bool> RegisterUser(AuthViewModel model, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState)
    {
        var user = new User{UserName = model.Username}; 
        var result = await _userManager.CreateAsync(user, model.Password);
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return result.Succeeded;
        
    }
    public async Task LogoutUser()
    {
        await _signInManager.SignOutAsync();
    }
}