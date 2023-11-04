using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StationeryStore.Data;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;

namespace StationeryStore.Controllers;

[Controller]
[Route("[controller]")]
public class AuthController : Controller
{ 
    // private readonly AdministratorSeedData _seedData;
    private readonly ILogger<AuthController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AuthController(ILogger<AuthController> logger, 
        UserManager<User> userManager, 
        // AdministratorSeedData seedData,
        SignInManager<User> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        // _seedData = seedData;
    }
    // [HttpGet("Login")]
    // public IActionResult Login()
    // {
    //     return View();
    // }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await _userManager.FindByNameAsync(model.Username);
        if(user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))
        {
            return Unauthorized();
        }
        await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        return Ok(user.Id);
    }
    // [HttpGet("Register")]
    // public IActionResult Register()
    // {
    //     return View();
    // }
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            
            var user = new User{UserName = model.Username}; 
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Accepted("Successful registration");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
            return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
        }
    }
    // [HttpPost("Logout")]
    // public IActionResult Logout()
    // {

    // }
    // [Authorize]
    // [HttpGet("test")]
    // public IActionResult Test()
    // {
    //     return Ok("Authorized");
    // }
}
