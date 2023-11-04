using Microsoft.EntityFrameworkCore;
using StationeryStore.Data;
namespace StationeryStore.Services;
public class ShopService
{
    private readonly ApplicationDbContext _dbContext;

    public ShopService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddToCart()
    {

    }
    public void DeleteFromCart()
    {
        
    }
}