using Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Application.Features.GitHubProfiles.Dtos;
using AutoMapper;


namespace Application.Features.GitHubProfiles.Profiles
{
    public class GitHubProfileMappingProfiles : Profile
    {
        public GitHubProfileMappingProfiles()
        {
            CreateMap<CreateGithubProfileCommand,CreatedGitHubProfileDto>().ReverseMap();
            CreateMap<UpdateGitHubProfileCommand,CreatedGitHubProfileDto>().ReverseMap();
            CreateMap<DeleteGitHubProfileCommand,CreatedGitHubProfileDto>().ReverseMap();
        }
    }
}
