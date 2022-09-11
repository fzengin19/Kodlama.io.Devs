using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class TechnologyMappingProfiles : Profile
    {
        public TechnologyMappingProfiles()
        {
            CreateMap<Technology, CrudTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

        }
    }
}
