using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StationeryStore.Models;
using StationeryStore.Services;

namespace StationeryStore.Controllers;

[Controller]
[Route("[controller]")]
public class AuthController : Controller
{ 
    private readonly ILogger<AuthController> _logger;
    private readonly AuthService _authService;
    public AuthController(ILogger<AuthController> logger, 
        AuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }
    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] AuthViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var userRoles = await _authService.LoginUser(model);
        if(userRoles == null)
            return BadRequest("Unauthorized");
        return Ok(userRoles);
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] AuthViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }         
        var result = await _authService.RegisterUser(model, ModelState);
        if (!result)
        {
            return BadRequest(ModelState);
        }
        return Accepted("Successful registration");
    }
    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutUser();
        return Accepted("Cookie was deleted");
    }
}
