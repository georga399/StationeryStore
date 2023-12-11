using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StationeryStore.Models;
using StationeryStore.Services;
using System.Security.Claims;

namespace StationeryStore.Controllers;
[Controller]
[Route("[controller]")]
public class ShopController: Controller
{
    private readonly ILogger<ShopController> _logger;
    private readonly ShopService _shopService;
    public ShopController(ILogger<ShopController> logger, ShopService shopService)
    {
        _logger = logger;
        _shopService = shopService;
    }
    [HttpGet("GetProducts")]
    public IActionResult GetProducts()
    {
        var models = _shopService.GetProducts();
        return View(models);
    }
    [HttpGet("getproductinfo/{id:int}")]
    public IActionResult GetProductInfo(int id)
    {
        var model = _shopService.GetProductInfo(id);
        return View(model);
    }
    [Authorize]
    [HttpGet("Cart")]
    public IActionResult GetCartList()
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var models = _shopService.GetCartProducts(userId!);
        return View(models);
    }    
    [Authorize]
    [HttpPost("AddToCart")]
    public IActionResult AddToCart(CartProductViewModel model)
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var res = _shopService.AddToCart(model, userId!);
        if(res == false)
            return BadRequest();
        return Accepted();
    }
    [Authorize]
    [HttpDelete("DeleteFromCart")]
    public IActionResult DeleteFromCart(CartProductViewModel model)
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var res = _shopService.DeleteFromCart(model, userId!);   
        if(res == false)
            return BadRequest();
        return Accepted();
    }
}