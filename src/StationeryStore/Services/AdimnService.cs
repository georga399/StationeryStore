using Microsoft.EntityFrameworkCore;
using StationeryStore.Data;
namespace StationeryStore.Services;
public class AdminService
{
    private readonly ApplicationDbContext _dbContext;
    public AdminService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void CreateCategory()
    {

    }
    public void CreateProduct()
    {

    }
    public void EditProduct()
    {
        
    }
}