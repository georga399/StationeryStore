using Microsoft.EntityFrameworkCore;
using StationeryStore.Entities.DAOs;
namespace StationeryStore.Data;
public class ApplicationDbContext : DbContext
{
    DbSet<User> Users => Set<User>();
    DbSet<Product> Products => Set<Product>();
    DbSet<Category> Categories => Set<Category>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}
}