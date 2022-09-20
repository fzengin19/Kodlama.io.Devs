using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Commands.DeleteDeveloper;
using Application.Features.Developers.Commands.UpdateDeveloper;
using Application.Features.Developers.Dtos;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Developers.Profiles
{
    public class DeveloperMappingProfiles : Profile
    {
        public DeveloperMappingProfiles()
        {
            CreateMap<Developer,CreateDeveloperCommand>().ReverseMap();
            CreateMap<Developer,CreatedDeveloperDto>().ReverseMap();

            CreateMap<Developer, UpdateDeveloperCommand>().ReverseMap();
            CreateMap<Developer, DeleteDeveloperCommand>().ReverseMap();
            CreateMap<Developer, GetByIdDeveloperDto>()
                .ForMember(d=> d.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.User.FirstName+" "+c.User.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(c=> c.User.Email)).ReverseMap();

        }
    }
}
