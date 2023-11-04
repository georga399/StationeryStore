using Microsoft.AspNetCore.Identity;
namespace StationeryStore.Data.DAOs;
public class User: IdentityUser
{
    public List<Product> Cart{get; set;} = new();
}