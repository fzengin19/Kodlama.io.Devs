using Application.Features.ProgrammingLanguageDevelopers.Commands.CreateProgrammingLanguageDeveloperCommand;
using Application.Features.ProgrammingLanguageDevelopers.Commands.DeleteProgrammingLanguageDeveloper;
using Application.Features.ProgrammingLanguageDevelopers.Commands.UpdateProgrammingLanguageDeveloper;
using Application.Features.ProgrammingLanguageDevelopers.Dtos;
using Application.Features.ProgrammingLanguages.Dtos;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.ProgrammingLanguageDevelopers.Profiles
{
    internal class ProgrammingLanguageDeveloperMappingProfiles : Profile
    {

            public ProgrammingLanguageDeveloperMappingProfiles()
            {
                CreateMap<ProgrammingLanguageDeveloper, CreateProgrammingLanguageDeveloperCommand>().ReverseMap();
                CreateMap<ProgrammingLanguageDeveloper, UpdateProgrammingLanguageDeveloperCommand>().ReverseMap();
                CreateMap<ProgrammingLanguageDeveloper, DeleteProgrammingLanguageDeveloperCommand>().ReverseMap();

                CreateMap<ProgrammingLanguageDeveloper, CreatedProgrammingLanguageDeveloperDto>().ReverseMap();
                CreateMap<ProgrammingLanguageDeveloper, UpdatedProgrammingLanguageDeveloperDto>().ReverseMap();
                CreateMap<ProgrammingLanguageDeveloper, DeletedProgrammingLanguageDeveloperDto>().ReverseMap();



            }

    }
}
