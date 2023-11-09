using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StationeryStore.Models;
using StationeryStore.Services;

namespace StationeryStore.Controllers;

[Authorize(Roles = "admin")]
[Controller]
[Route("[controller]")]
public class ManageController : Controller
{
    private readonly ILogger<ManageController> _logger;
    private readonly AdminService _adminService;

    public ManageController(ILogger<ManageController> logger,
        AdminService adminService)
    {
        _logger = logger;
        _adminService = adminService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return View(); //Todo: create view
    }
    [HttpPost("CreateCategory")]
    public IActionResult CreateCategory(CategoryViewModel category)
    {
        _adminService.CreateCategory(category);
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