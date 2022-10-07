using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;


namespace Application.Features.Developers.Profiles
{
    public class UserMappingProfiles :Profile 
    {
        public UserMappingProfiles()
        {
            CreateMap<User,RegisteredModel>().ReverseMap();
            CreateMap<User,RegisteredDto>().ReverseMap();
            CreateMap<User,RegisterCommand>().ReverseMap();
            CreateMap<User,LoginedUserDto>().ForMember(u => u.Name ,opt => opt.MapFrom(u => u.FirstName+" "+u.LastName)).ReverseMap();
            CreateMap<User,UserForRegisterDto>().ReverseMap();
        }
    }
}
