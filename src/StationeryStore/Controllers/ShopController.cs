namespace StationeryStore.Controllers;
public class ShopController
{
    private readonly ILogger<ShopController> _logger;

    public ShopController(ILogger<ShopController> logger)
    {
        _logger = logger;
    }
}