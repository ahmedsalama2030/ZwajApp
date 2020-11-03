using System;
using System.Linq;
using AutoMapper;
using ZwajApp.API.Dtos;
using ZwajApp.API.Models;

namespace ZwajApp.API.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles( )
        {
            CreateMap<User,UserForListDto>()
            .ForMember(dest=>dest.photoURL,
            o =>{o.MapFrom(s =>s.Photos.FirstOrDefault(x=>x.IsMain).Url);})
         .ForMember(des => des.Age,o => {o .ResolveUsing(s=>s.DateOfBirth.CalculateAge());});
            
         
            CreateMap<User,UsersForDetials>()
            .ForMember(dest=>dest.photoURL,
            o =>{o.MapFrom(s =>s.Photos.FirstOrDefault(x=>x.IsMain).Url);})
            .ForMember(des => des.Age,o => {o .ResolveUsing(s=>s.DateOfBirth.CalculateAge());})
            ;
            
            CreateMap<Photoer,PhotoForDetailsDTO>();
        }
    }
}