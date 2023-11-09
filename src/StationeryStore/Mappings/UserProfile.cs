using AutoMapper;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;

namespace StationeryStore.Mappings;
public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>()
        .ForMember(dst => dst.Name, opt => opt.MapFrom(x=> x.UserName))
        .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.Id))
        .ForMember(dst => dst.Cart, opt => opt.MapFrom(x => x.Cart));
        CreateMap<UserViewModel, User>();
    }
}