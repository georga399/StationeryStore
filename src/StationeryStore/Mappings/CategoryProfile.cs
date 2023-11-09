using AutoMapper;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;

namespace StationeryStore.Mappings;
public class CategoryProfile: Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryViewModel>()
        .ForMember(dst => dst.Id, opt => opt.MapFrom(x=>x.Id))
        .ForMember(dst => dst.Name, opt => opt.MapFrom(x=>x.Name))
        .ForMember(dst => dst.Products, opt => opt.MapFrom(x=>x.Products));
        CreateMap<CategoryViewModel, Category>();
    }
}