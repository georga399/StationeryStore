namespace StationeryStore.Models;
public class CartProductViewModel
{
    public int Id{get;set;}
    public ProductViewModel Product{get; set;} = null!;
    public int Count{get; set;}
    public UserViewModel User{get; set;} = null!;
    public string UserId{get;set;} = null!;
}