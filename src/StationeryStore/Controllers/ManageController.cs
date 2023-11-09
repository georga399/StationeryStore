using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StationeryStore.Models;

namespace StationeryStore.Controllers;

[Authorize(Roles = "admin")]
[Controller]
[Route("[controller]")]
public class ManageController : Controller
{
    private readonly ILogger<ManageController> _logger;

    public ManageController(ILogger<ManageController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return View(); //Todo: create view
    }
    [HttpPost("CreateCategory")]
    public IActionResult CreateCategory(CategoryViewModel category)
    {
        return Accepted();
    }
    [HttpPost("CreateProduct")]
    public IActionResult CreateProduct(ProductViewModel product)
    {
        return Accepted();
    }
    [HttpDelete("DeleteCategory")]
    public IActionResult DeleteCategory(CategoryViewModel category)
    {
        return Accepted();
    }
    [HttpDelete("DeleteProduct")]
    public IActionResult DeleteProduct(ProductViewModel product)
    {
        return Accepted();
    }
}