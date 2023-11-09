using Microsoft.AspNetCore.Identity;
namespace StationeryStore.Data.DAOs;
public class User: IdentityUser
{
    public List<CartProduct> Cart{get; set;} = new();
}