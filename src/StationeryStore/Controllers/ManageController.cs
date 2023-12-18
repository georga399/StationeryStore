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
    private readonly ShopService _shopService;


    public ManageController(ILogger<ManageController> logger,
        AdminService adminService,
        ShopService shopService)
    {
        _logger = logger;
        _adminService = adminService;
        _shopService = shopService;

    }
    [HttpGet]
    public IActionResult Get()
    {
        var models = _shopService.GetProducts();
        return View(models); 
    }
    [HttpPost("CreateProduct")]
    public IActionResult CreateProduct(ProductViewModel product)
    {
        var res = _adminService.CreateProduct(product);
        if(res)
            return Accepted();
        return BadRequest("Wrong format of data");
    }
    [HttpPut("EditProduct")]
    public IActionResult EditProduct(ProductViewModel product)
    {
        var res = _adminService.EditProduct(product);
        if(res)
            return Accepted();
        return BadRequest();
    }
    [HttpDelete("DeleteProduct")]
    public IActionResult DeleteProduct(ProductViewModel product)
    {
        var res = _adminService.DeleteProduct(product);
        if(res)
            return Accepted();
        return BadRequest();
    }
}