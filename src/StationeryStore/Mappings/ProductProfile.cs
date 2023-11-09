using AutoMapper;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;

namespace StationeryStore.Mappings;
public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductViewModel>()
        .ForMember(dst => dst.Id, opt => opt.MapFrom(x=>x.Id))
        .ForMember(dst => dst.Name, opt => opt.MapFrom(x=>x.Name))
        .ForMember(dst => dst.Cost, opt => opt.MapFrom(x=>x.Cost))
        .ForMember(dst => dst.Category, opt => opt.MapFrom(x => x.Category))
        .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(x => x.CategoryId));
        CreateMap<ProductViewModel, Product>();
    }
}