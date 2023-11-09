using Microsoft.EntityFrameworkCore;
using StationeryStore.Data;
namespace StationeryStore.Services;
public class UserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}