namespace StationeryStore.Models;
public class CategoryViewModel
{
    public int Id{get; set;}
    public string Name{get; set;} = "";
    public List<ProductViewModel> Products{get; set;} = new();
}