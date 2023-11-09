namespace StationeryStore.Models;
public class ProductViewModel
{
    public int Id{get; set;}
    public string Name{get; set;} = "";
    public decimal Cost{get; set;}
    public CategoryViewModel? Category{get; set;}
    public int CategoryId{get;set;}
}