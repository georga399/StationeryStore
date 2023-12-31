using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StationeryStore.Data.DAOs;
namespace StationeryStore.Data;
public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Product> Products {get; set;} = null!;
    public DbSet<CartProduct> CartProducts{get; set;} = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
}