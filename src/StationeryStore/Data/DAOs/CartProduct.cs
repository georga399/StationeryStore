namespace StationeryStore.Data.DAOs;
public class CartProduct
{
    public int Id{get;set;}
    public Product Product{get; set;} = null!;
    public int ProductId{get;set;}
    public int Count{get; set;}
    public User User{get; set;} = null!;
    public string UserId{get;set;} = null!;
}