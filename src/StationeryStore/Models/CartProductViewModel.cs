namespace StationeryStore.Models;
public class CartProductViewModel
{
    public int Id{get;set;}
    public ProductViewModel Product{get; set;} = null!;
    public int ProductId{get;set;}
    public int Count{get; set;}
    public UserViewModel? User{get; set;}
    public string UserId{get;set;} = null!;
}