namespace StationeryStore.Data.DAOs;
public class Product
{
    public int Id{get; set;}
    public string Name{get; set;} = "";
    public decimal Cost{get; set;}
    public Category Category{get; set;} = null!;
    public int CategoryId{get;set;}
}