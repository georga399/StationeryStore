namespace StationeryStore.Models;
public class UserViewModel
{
    public string Name{get; set;} = "";
    public List<CartProductViewModel> Cart{get; set;} = new();
}