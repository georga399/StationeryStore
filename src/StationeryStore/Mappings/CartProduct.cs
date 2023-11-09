using AutoMapper;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;

namespace StationeryStore.Mappings;
public class CartProductProfile: Profile
{
    public CartProductProfile()
    {
        CreateMap<CartProduct, CartProductViewModel>()
        .ForMember(dst => dst.Id, opt => opt.MapFrom(x=>x.Id))
        .ForMember(dst => dst.User, opt => opt.MapFrom(x=>x.User))
        .ForMember(dst => dst.UserId, opt => opt.MapFrom(x=>x.User.Id))
        .ForMember(dst => dst.Count, opt => opt.MapFrom(x => x.Count))
        .ForMember(dst => dst.Product, opt => opt.MapFrom(x => x.Product))
        .ForMember(dst => dst.ProductId, opt => opt.MapFrom(x => x.ProductId));
        CreateMap<CartProductViewModel, CartProduct>();
    }
}