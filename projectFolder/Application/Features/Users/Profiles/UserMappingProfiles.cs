﻿using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Security.Entities;


namespace Application.Features.Developers.Profiles
{
    public class UserMappingProfiles :Profile 
    {
        public UserMappingProfiles()
        {
            CreateMap<User,CreatedUserModel>().ReverseMap();
            CreateMap<User,CreatedUserDto>().ReverseMap();
            CreateMap<User,CreateUserCommand>().ReverseMap();
            CreateMap<User,UserLoginDto>().ForMember(u => u.Name ,opt => opt.MapFrom(u => u.FirstName+" "+u.LastName)).ReverseMap();
        }
    }
}
