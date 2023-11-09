using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StationeryStore.Models;

namespace StationeryStore.Controllers;
[Controller]
[Route("[controller]")]
public class ShopController: Controller
{
    private readonly ILogger<ShopController> _logger;

    public ShopController(ILogger<ShopController> logger)
    {
        _logger = logger;
    }
    [HttpGet("getproducts/category={category}/page={page:int}")]
    public IActionResult GetProducts(string category, int page)
    {
        return Accepted();
    }
    [HttpGet("getproductinfo/{id:int}")]
    public IActionResult GetProductInfo(int id)
    {
        return Accepted();
    }
    [Authorize]
    [HttpGet("Cart")]
    public IActionResult GetCartList()
    {
        return Accepted();
    }    
    [Authorize]
    [HttpPost("AddToCart")]
    public IActionResult AddToCart(ProductViewModel product)
    {
        return Accepted();
    }
    [Authorize]
    [HttpDelete("DeleteFromCart")]
    public IActionResult DeleteFromCart(ProductViewModel product)
    {
        return Accepted();
    }
}